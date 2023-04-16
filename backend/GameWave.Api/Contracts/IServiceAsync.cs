using System.Collections.Generic;
using System.Threading.Tasks;

using GameWave.ObjectModel;

namespace GameWave.API.Contracts
{
    public interface IServiceAsync<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id);

        Task<T> CreateAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(long id);

        Task<bool> DeleteAsync(IEnumerable<T> entities);
    }
}