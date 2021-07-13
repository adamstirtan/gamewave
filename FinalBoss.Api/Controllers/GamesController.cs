using System.Threading.Tasks;
using AutoMapper;
using FinalBoss.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FinalBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase, IApiController<GameDto>
    {
        private readonly IMapper _mapper;

        public GamesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<IActionResult> Create(GameDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Get(string sort = "id", bool paged = false, int page = 1, int pageSize = 100, bool ascending = true)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> Update(long id, GameDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}