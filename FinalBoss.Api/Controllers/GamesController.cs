using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using FinalBoss.Api.Dto;
using FinalBoss.Api.Extensions;
using FinalBoss.Core.Extensions;
using FinalBoss.Database.Services;
using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase, IApiController<GameDto>
    {
        private readonly IMapper _mapper;
        private readonly IGameService _gameService;

        public GamesController(
            IMapper mapper,
            IGameService gameService)
        {
            _mapper = mapper;
            _gameService = gameService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(string sort = "id", bool paged = false, int page = 1, int pageSize = 100, bool ascending = true)
        {
            var sortProperty = _mapper
                .ConfigurationProvider
                .FindTypeMapFor(typeof(Game), typeof(GameDto))
                .PropertyMaps
                .FirstOrDefault(x =>
                    string.Equals(x.DestinationName, sort, StringComparison.InvariantCultureIgnoreCase))?.SourceMember.Name ?? sort;

            try
            {
                if (!paged)
                {
                    return Ok(_mapper.Map<GameDto[]>(
                        _gameService
                        .All()
                        .OrderByPropertyOrField(sortProperty, ascending)));
                }

                page = Math.Max(1, page);
                pageSize = Math.Max(1, pageSize);

                return Ok(this.CreatePagedResults<Game, GameDto>(
                    _mapper,
                    _gameService.Page(x => true, sortProperty, page, pageSize, ascending),
                    _gameService.Count(),
                    page, pageSize,
                    sort,
                    ascending));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetById(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> Create(GameDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<IActionResult> Update(long id, GameDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public Task<IActionResult> Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}