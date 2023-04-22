using GameWave.ObjectModel;

namespace GameWave.API.Contracts
{
    public interface ISearch<TEntity> where TEntity : BaseEntity, new()
    {
        long? Id { get; set; }

        IQueryObject<TEntity> ToQueryObject();
    }
}
