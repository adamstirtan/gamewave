using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using GameWave.API.Contracts;
using GameWave.API.DTO;
using GameWave.API.Extensions;
using GameWave.ObjectModel;

namespace GameWave.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly string RouteName = "user";

        private readonly ILogger<UsersController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        public UsersController(
            ILogger<UsersController> logger,
            UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            _logger = logger;
            _userManager = userManager;
            _userService = userService;
        }

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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> GetById(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user is null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Create(CreateUserDTO dto)
        {
            try
            {
                DateTimeOffset now = DateTimeOffset.UtcNow;

                ApplicationUser user = new()
                {
                    UserName = dto.Email,
                    Email = dto.Email,
                    LastModified = now,
                    Created = now
                };

                IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

                if (result.Succeeded)
                {
                    return Created($"/{RouteName}/{user.Id}", user);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return BadRequest(ModelState);
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Update(string id, ApplicationUser dto)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(id);

                if (user is null)
                {
                    return NotFound();
                }

                user.UserName = dto.UserName;
                user.Email = dto.Email;
                user.PhoneNumber = dto.PhoneNumber;
                user.LastModified = DateTimeOffset.UtcNow;

                IdentityResult result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Ok(user);
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Delete(string id)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(id);

                if (user is null)
                {
                    return NotFound();
                }

                IdentityResult result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
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

            return new PagedEntity<ApplicationUser>
            {
                Items = enumerable,
                PageNumber = page,
                PageSize = enumerable.Count(),
                TotalPages = totalPageCount,
                TotalItems = totalItems,
                Sort = JsonNamingPolicy.CamelCase.ConvertName(sort),
                Ascending = ascending
            };
        }
    }
}