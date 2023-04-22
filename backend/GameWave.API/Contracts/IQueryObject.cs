using System;
using System.Linq.Expressions;

namespace GameWave.API.Contracts
{
    public interface IQueryObject<T>
    {
        Expression<Func<T, bool>> Query();

        Expression<Func<T, bool>> And(Expression<Func<T, bool>> query);

        Expression<Func<T, bool>> And(IQueryObject<T> queryObject);

        Expression<Func<T, bool>> Or(Expression<Func<T, bool>> query);

        Expression<Func<T, bool>> Or(IQueryObject<T> queryObject);
    }
}
