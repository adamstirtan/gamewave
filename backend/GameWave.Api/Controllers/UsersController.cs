using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using GameWave.Api.Extensions;
using GameWave.Api.Services;
using GameWave.ObjectModel;

namespace GameWave.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        private string RouteName => "user";

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual ActionResult<IEnumerable<ApplicationUser>> Get(string sort, bool paged = false, int page = 1, int pageSize = 100, bool ascending = true)
        {
            try
            {
                string sortProperty = typeof(ApplicationUser)
                    .GetProperties()
                    .FirstOrDefault(x =>
                        string.Equals(x.Name, sort, StringComparison.InvariantCultureIgnoreCase))?.Name ?? "id";

                if (!paged)
                {
                    return Ok(
                        _userService
                        .All()
                        .OrderByPropertyOrField(sortProperty, ascending));
                }

                page = Math.Max(1, page);
                pageSize = Math.Max(1, pageSize);

                return Ok(CreatePagedResults(
                    _userService.Page(x => true, sortProperty, page, pageSize, ascending),
                    _userService.Count(),
                    sort,
                    ascending,
                    page,
                    pageSize));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        protected PagedEntity<ApplicationUser> CreatePagedResults(IEnumerable<ApplicationUser> enumerable,
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

            return new PagedEntity<ApplicationUser>
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