using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameWave.Api.Services
{
    public interface IServiceAsync<T> where T : class
    {
        Task<T> GetByIdAsync(long id);

        Task<T> CreateAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(long id);

        Task<bool> DeleteAsync(IEnumerable<T> entities);
    }
}