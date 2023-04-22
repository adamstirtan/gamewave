using System;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using GameWave.API.Contracts;
using GameWave.API.Extensions;
using GameWave.API.Search;
using GameWave.ObjectModel;

namespace GameWave.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ApiController<Company, ICompanyService>, ISearchableController<Company, CompanySearch>
    {
        public CompanyController(
            ILogger<CompanyController> logger,
            ICompanyService companyService)
            : base(logger, companyService)
        { }

        protected override string RouteName => "company";

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Search([FromQuery] CompanySearch search, string sort, bool paged = false, int page = 1, int pageSize = 100, bool ascending = true)
        {
            if (search is null)
            {
                return BadRequest();
            }

            try
            {
                string sortProperty = typeof(Company)
                    .GetProperties()
                    .FirstOrDefault(x =>
                        string.Equals(x.Name, sort, StringComparison.InvariantCultureIgnoreCase))?.Name ?? "id";

                var query = search.ToQueryObject().Query();

                if (query is null)
                {
                    return BadRequest();
                }

                if (!paged)
                {
                    return Ok(
                        Service
                        .Where(query)
                        .OrderByPropertyOrField(sortProperty, ascending));
                }

                page = Math.Max(1, page);
                pageSize = Math.Max(1, pageSize);

                return Ok(CreatePagedResults(
                    Service.Page(query, sortProperty, page, pageSize, ascending),
                    Service.Count(query),
                    sortProperty,
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
    }
}