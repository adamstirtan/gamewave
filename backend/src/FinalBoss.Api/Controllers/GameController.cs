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
    public class GameController : ApiController<Game, GameDto, IGameService>
    {
        public GameController(
            ILogger<GameController> logger,
            IMapper mapper,
            IGameService gameService)
            : base(logger, mapper, gameService)
        { }

        protected override string RouteName => "game";
    }
}