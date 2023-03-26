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
    public class PlatformController : ApiController<Platform, PlatformDto, IPlatformService>
    {
        public PlatformController(
            ILogger<PlatformController> logger,
            IMapper mapper,
            IPlatformService platformService)
            : base(logger, mapper, platformService)
        { }

        protected override string RouteName => "platform";
    }
}