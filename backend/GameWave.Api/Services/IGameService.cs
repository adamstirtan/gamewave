using GameWave.ObjectModel;

namespace GameWave.Api.Services
{
    public interface IGameService : IService<Game>, IServiceAsync<Game>
    { }
}