using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using FinalBoss.Api.Services;
using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Controllers
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