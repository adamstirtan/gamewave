using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Controllers
{
    internal interface IApiController<TEntity> where TEntity : BaseEntity
    {
        IActionResult Get(string sort = "id", bool paged = false, int page = 1, int pageSize = 100, bool ascending = true);

        Task<IActionResult> GetById(long id);

        Task<IActionResult> Create(TEntity dto);

        Task<IActionResult> Update(long id, TEntity entity);

        Task<IActionResult> Delete(long id);
    }
}