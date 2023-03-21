using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.Internal;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using FinalBoss.Api.Dto;
using FinalBoss.Api.Services;
using FinalBoss.Extensions;
using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Controllers
{
    public abstract class ApiController<TEntity, TDto, TService> : ControllerBase
        where TEntity : BaseEntity
        where TDto : BaseDto
        where TService : IService<TEntity>, IServiceAsync<TEntity>
    {
        private readonly ILogger<ApiController<TEntity, TDto, TService>> _logger;
        private readonly IMapper _mapper;

        protected readonly TService Service;

        protected ApiController(
            ILogger<ApiController<TEntity, TDto, TService>> logger,
            IMapper mapper,
            TService service)
        {
            _logger = logger;
            _mapper = mapper;

            Service = service;
        }

        protected abstract string RouteName { get; }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual ActionResult<IEnumerable<TDto>> Get(string sort = "id", bool paged = false, int page = 1, int pageSize = 100, bool ascending = true)
        {
            try
            {
                string sortProperty = _mapper
                    .ConfigurationProvider
                    .Internal()
                    .FindTypeMapFor(typeof(TEntity), typeof(TDto))
                    .PropertyMaps
                    .FirstOrDefault(x =>
                        string.Equals(x.DestinationName, sort, StringComparison.InvariantCultureIgnoreCase))?.SourceMember.Name ?? sort;

                if (!paged)
                {
                    return Ok(_mapper.Map<TDto[]>(
                        Service
                        .All()
                        .OrderByPropertyOrField(sortProperty, ascending)));
                }

                page = Math.Max(1, page);
                pageSize = Math.Max(1, pageSize);

                return Ok(CreatePagedResults(
                    Service.Page(x => true, sortProperty, page, pageSize, ascending),
                    Service.Count(),
                    page, pageSize,
                    sort,
                    ascending));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

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

                return Ok(_mapper.Map<TDto>(entity));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Create(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);

                DateTimeOffset now = DateTimeOffset.UtcNow;

                entity.Created = now;
                entity.LastModified = now;

                entity = await Service.CreateAsync(entity);

                return Created($"/{RouteName}/{entity.Id}", _mapper.Map<TDto>(entity));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Update(long id, TDto dto)
        {
            try
            {
                var entity = await Service.GetByIdAsync(id);

                if (entity is null)
                {
                    return NotFound();
                }

                _mapper.Map(dto, entity);

                entity.LastModified = DateTimeOffset.UtcNow;

                bool updated = await Service.UpdateAsync(entity);

                if (updated)
                {
                    return Ok(_mapper.Map<TDto>(entity));
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch
            {
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private PagedDto<TDto> CreatePagedResults(IEnumerable<TEntity> enumerable,
            int totalItems,
            int page,
            int pageSize,
            string sort,
            bool ascending)
        {
            var items = _mapper.Map<TDto[]>(enumerable);

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

            return new PagedDto<TDto>
            {
                Items = items,
                PageNumber = page,
                PageSize = items.Length,
                TotalPages = totalPageCount,
                TotalItems = totalItems,
                PreviousUrl = previousUrl,
                NextUrl = nextUrl
            };
        }
    }
}