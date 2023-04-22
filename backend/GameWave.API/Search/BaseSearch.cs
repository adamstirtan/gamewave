using GameWave.API.Contracts;

namespace GameWave.API.Search
{
    public abstract class BaseSearch<TEntity>
    {
        public long? Id { get; set; }

        public abstract IQueryObject<TEntity> ToQueryObject();
    }
}
