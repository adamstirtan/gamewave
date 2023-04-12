using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GameWave.Api.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> OrderByPropertyOrField<T>(this IEnumerable<T> enumerable, string propertyOrFieldName, bool ascending)
        {
            var elementType = typeof(T);
            var orderByMethodName = ascending ? "OrderBy" : "OrderByDescending";

            var parameterExpression = Expression.Parameter(elementType);
            var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, propertyOrFieldName);
            var selector = Expression.Lambda(propertyOrFieldExpression, parameterExpression);

            var queryable = enumerable.AsQueryable();

            var orderByExpression = Expression.Call(
                typeof(Queryable),
                orderByMethodName,
                new[]
                {
                    elementType, propertyOrFieldExpression.Type
                },
                queryable.Expression,
                selector);

            return queryable.Provider.CreateQuery<T>(orderByExpression);
        }
    }
}