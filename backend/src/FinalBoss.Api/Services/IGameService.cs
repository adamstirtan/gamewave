using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Services
{
    public interface IGameService : IService<Game>, IServiceAsync<Game>
    { }
}