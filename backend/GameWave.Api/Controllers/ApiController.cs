using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using GameWave.Api.Extensions;
using GameWave.Api.Services;
using GameWave.ObjectModel;

namespace GameWave.Api.Controllers
{
    public abstract class ApiController<TEntity, TService> : ControllerBase
        where TEntity : BaseEntity
        where TService : IService<TEntity>, IServiceAsync<TEntity>
    {
        protected readonly ILogger<ApiController<TEntity, TService>> Logger;
        protected readonly TService Service;

        protected ApiController(
            ILogger<ApiController<TEntity, TService>> logger,
            TService service)
        {
            Logger = logger;
            Service = service;
        }

        protected abstract string RouteName { get; }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual ActionResult<IEnumerable<TEntity>> Get(string sort, bool paged = false, int page = 1, int pageSize = 100, bool ascending = true)
        {
            try
            {
                string sortProperty = typeof(TEntity)
                    .GetProperties()
                    .FirstOrDefault(x =>
                        string.Equals(x.Name, sort, StringComparison.InvariantCultureIgnoreCase))?.Name ?? "id";

                if (!paged)
                {
                    return Ok(
                        Service
                        .All()
                        .OrderByPropertyOrField(sortProperty, ascending));
                }

                page = Math.Max(1, page);
                pageSize = Math.Max(1, pageSize);

                return Ok(CreatePagedResults(
                    Service.Page(x => true, sortProperty, page, pageSize, ascending),
                    Service.Count(),
                    sort,
                    ascending,
                    page,
                    pageSize));
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> GetById(long id)
        {
            try
            {
                var entity = await Service.GetByIdAsync(id);

                if (entity is null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Create(TEntity entity)
        {
            try
            {
                DateTimeOffset now = DateTimeOffset.UtcNow;

                entity.Created = now;
                entity.LastModified = now;

                entity = await Service.CreateAsync(entity);

                return Created($"/{RouteName}/{entity.Id}", entity);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Update(long id, TEntity dto)
        {
            try
            {
                var entity = await Service.GetByIdAsync(id);

                if (entity is null)
                {
                    return NotFound();
                }

                entity.Merge(entity, dto);
                entity.LastModified = DateTimeOffset.UtcNow;

                bool updated = await Service.UpdateAsync(entity);

                if (updated)
                {
                    return Ok(entity);
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Delete(long id)
        {
            try
            {
                var entity = await Service.GetByIdAsync(id);

                if (entity is null)
                {
                    return NotFound();
                }

                bool deleted = await Service.DeleteAsync(id);

                if (deleted)
                {
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        protected PagedEntity<TEntity> CreatePagedResults(IEnumerable<TEntity> enumerable,
            int totalItems,
            string sort,
            bool ascending,
            int page,
            int pageSize)
        {
            var mod = totalItems % pageSize;
            var totalPageCount = totalItems / pageSize + (mod == 0 ? 0 : 1);

            var previousUrl = page <= 1
                ? null
                : Url?.Link(null, new
                {
                    paged = true,
                    page = page - 1,
                    pageSize,
                    sort,
                    ascending
                }).ToLower();

            var nextUrl = page >= totalPageCount
                ? null
                : Url?.Link(null, new
                {
                    paged = true,
                    page = page + 1,
                    pageSize,
                    sort,
                    ascending
                }).ToLower();

            return new PagedEntity<TEntity>
            {
                Items = enumerable,
                PageNumber = page,
                PageSize = enumerable.Count(),
                TotalPages = totalPageCount,
                TotalItems = totalItems,
                PreviousUrl = previousUrl,
                NextUrl = nextUrl,
                Sort = sort,
                Ascending = ascending
            };
        }
    }
}