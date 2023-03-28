using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using FinalBoss.Api.Services;
using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlatformController : ApiController<Platform, IPlatformService>
    {
        public PlatformController(
            ILogger<PlatformController> logger,
            IPlatformService platformService)
            : base(logger, platformService)
        { }

        protected override string RouteName => "platform";
    }
}