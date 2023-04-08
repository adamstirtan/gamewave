using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using FinalBoss.Api.Extensions;
using FinalBoss.Api.Services;
using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ApiController<Company, ICompanyService>
    {
        public CompanyController(
            ILogger<CompanyController> logger,
            ICompanyService companyService)
            : base(logger, companyService)
        { }

        protected override string RouteName => "company";

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Company>> Search(string query, string sort = "id", bool paged = false, int page = 1, int pageSize = 100, bool ascending = true)
        {
            try
            {
                string sortProperty = typeof(Company)
                    .GetProperties()
                    .FirstOrDefault(x =>
                        string.Equals(x.Name, sort, StringComparison.InvariantCultureIgnoreCase))?.Name ?? "id";

                Expression<Func<Company, bool>> search =
                    x => EF.Functions.Like(x.Name, $"%{query}%");

                if (!paged)
                {
                    return Ok(Service
                        .Where(search)
                        .OrderByPropertyOrField(sortProperty, ascending));
                }

                page = Math.Max(1, page);
                pageSize = Math.Max(1, pageSize);

                IEnumerable<Company> results =
                    Service.Page(search, sortProperty, page, pageSize, ascending);

                return Ok(CreatePagedResults(
                    results,
                    results.Count(),
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
    }
}