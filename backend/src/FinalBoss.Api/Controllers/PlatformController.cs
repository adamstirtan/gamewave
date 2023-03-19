using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AutoMapper;

using FinalBoss.Api.Dto;
using FinalBoss.Api.Services;
using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ApiController<Company, CompanyDto, ICompanyService>
    {
        public CompanyController(
            ILogger<CompanyController> logger,
            IMapper mapper,
            ICompanyService companyService)
            : base(logger, mapper, companyService)
        { }

        protected override string RouteName => "company";
    }
}