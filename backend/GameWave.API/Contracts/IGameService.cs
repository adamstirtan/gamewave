using GameWave.ObjectModel;

namespace GameWave.API.Contracts
{
    public interface IGameService : IService<Game>, IServiceAsync<Game>
    { }
}