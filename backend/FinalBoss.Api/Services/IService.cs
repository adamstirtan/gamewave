using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Services
{
    public interface IService<T> where T : BaseEntity
    {
        int Count();

        int Count(Expression<Func<T, bool>> query);

        IQueryable<T> All();

        IEnumerable<T> Page(Expression<Func<T, bool>> query, string sort = "id", int page = 1, int pageSize = 100, bool ascending = true);

        //IEnumerable<T> Page(Func<T, bool> query, string sort = "id", int page = 1, int pageSize = 100, bool ascending = true);

        IEnumerable<T> Where(Expression<Func<T, bool>> expression);

        T GetById(long id);

        T Create(T entity);

        bool Update(T entity);

        bool Delete(long id);

        bool Delete(IEnumerable<T> entities);
    }
}