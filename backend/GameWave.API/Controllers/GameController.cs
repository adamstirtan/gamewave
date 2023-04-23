using Microsoft.Extensions.Logging;

using GameWave.API.Contracts;
using GameWave.ObjectModel;

namespace GameWave.API.Controllers
{
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