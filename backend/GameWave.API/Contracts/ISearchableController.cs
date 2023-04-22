using Microsoft.AspNetCore.Mvc;

using GameWave.API.Search;
using GameWave.ObjectModel;

namespace GameWave.API.Contracts
{
    public interface ISearchableController<TEntity, TSearch>
        where TEntity : BaseEntity
        where TSearch : BaseSearch<TEntity>
    {
        ActionResult Search(TSearch search, string sort, bool paged = false, int page = 1, int pageSize = 100, bool ascending = true);
    }
}