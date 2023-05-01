using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using GameWave.API.Contracts;
using GameWave.API.Extensions;
using GameWave.ObjectModel;
using GameWave.API.DTO;

namespace GameWave.API.Controllers
{

    [ApiController]
	[Produces("application/json")]
	[Route("api/v1/[controller]")]
	public class DashboardController : ControllerBase
	{
		private readonly ILogger<DashboardController> _logger;
		private readonly IGameService _gameService;
        private readonly IPlatformService _platformService;

        public DashboardController(
			ILogger<DashboardController> logger,
			IGameService gameService,
			IPlatformService platformService)
		{
			_logger = logger;
			_gameService = gameService;
			_platformService = platformService;
		}

		[HttpGet("gamesbyplatform")]
		[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult GetGamesByPlatform()
		{
			try
			{
				Dictionary<string, int> data = new();

				var platforms = _platformService.All().OrderBy(x => x.Name);

				foreach (var platform in platforms)
				{
					int count = _gameService.Count(x => x.PlatformId == platform.Id);

					if (count > 0)
					{
						data.Add(platform.Name, count);
					}
				}

				return Ok(new GamesByPlatformDTO
				{
					Labels = data.Keys.ToArray(),
					Values = data.Values.ToArray()
				});
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

