using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using GameWave.ObjectModel;

namespace GameWave.API.Contracts
{
    public interface IService<TEntity> where TEntity : BaseEntity
    {
        int Count();

        int Count(Expression<Func<TEntity, bool>> query);

        IQueryable<TEntity> All();

        IEnumerable<TEntity> Page(Expression<Func<TEntity, bool>> query, string sort = "id", int page = 1, int pageSize = 100, bool ascending = true);

        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        TEntity GetById(long id);

        TEntity Create(TEntity dto);

        bool Update(TEntity dto);

        bool Delete(long id);

        bool Delete(IEnumerable<TEntity> dtos);
    }
}