using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using GameWave.ObjectModel;

namespace GameWave.API.Contracts
{
    public interface IService<T> where T : BaseEntity
    {
        int Count();

        int Count(Expression<Func<T, bool>> query);

        IQueryable<T> All();

        IEnumerable<T> Page(Expression<Func<T, bool>> query, string sort = "id", int page = 1, int pageSize = 100, bool ascending = true);

        IEnumerable<T> Where(Expression<Func<T, bool>> expression);

        T GetById(long id);

        T Create(T dto);

        bool Update(T dto);

        bool Delete(long id);

        bool Delete(IEnumerable<T> dtos);
    }
}