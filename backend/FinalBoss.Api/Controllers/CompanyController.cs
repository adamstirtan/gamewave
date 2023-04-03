using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}