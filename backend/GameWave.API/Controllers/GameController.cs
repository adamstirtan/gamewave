using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using GameWave.API.Contracts;
using GameWave.ObjectModel;

namespace GameWave.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GameController : ApiController<Game, IGameService>
    {
        public GameController(
            ILogger<GameController> logger,
            IGameService gameService)
            : base(logger, gameService)
        { }

        protected override string RouteName => "game";
    }
}