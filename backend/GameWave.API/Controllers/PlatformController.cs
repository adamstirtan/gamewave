using System;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using GameWave.API.Contracts;
using GameWave.ObjectModel;

namespace GameWave.API.Controllers
{
    public class PlatformController : ApiController<Platform, IPlatformService>
    {
        public PlatformController(
            ILogger<PlatformController> logger,
            IPlatformService platformService)
            : base(logger, platformService)
        { }

        protected override string RouteName => "platform";

        [HttpGet("category")]
        public ActionResult GetCategories()
        {
            try
            {
                var categories = Enum.GetValues(typeof(PlatformCategory))
                    .Cast<PlatformCategory>()
                    .Select(x => new
                    {
                        Id = (int)x,
                        Name = x.ToString()
                    })
                    .ToList();

                return Ok(categories);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}