using System.Collections.Generic;
using System.Threading.Tasks;

using GameWave.ObjectModel;

namespace GameWave.API.Contracts
{
    public interface IServiceAsync<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(long id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(long id);

        Task<bool> DeleteAsync(IEnumerable<TEntity> entities);
    }
}