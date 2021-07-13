using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using FinalBoss.Api.Dto;

namespace FinalBoss.Api.Controllers
{
    internal interface IApiController<TDto> where TDto : BaseDto
    {
        IActionResult Get(string sort = "id", bool paged = false, int page = 1, int pageSize = 100, bool ascending = true);

        Task<IActionResult> GetById(long id);

        Task<IActionResult> Create(TDto dto);

        Task<IActionResult> Update(long id, TDto dto);

        Task<IActionResult> Delete(long id);
    }
}