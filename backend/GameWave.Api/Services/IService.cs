using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GameWave.Api.Services
{
    public interface IService<T> where T : class
    {
        int Count();

        int Count(Expression<Func<T, bool>> expression);

        IQueryable<T> All();

        IEnumerable<T> Page(Expression<Func<T, bool>> express, string sort = "id", int page = 1, int pageSize = 100, bool ascending = true);

        IEnumerable<T> Where(Expression<Func<T, bool>> expression);

        T GetById(long id);

        T Create(T entity);

        bool Update(T entity);

        bool Delete(long id);

        bool Delete(IEnumerable<T> entities);
    }
}