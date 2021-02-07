using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Services
{
    public interface IGameService : IService<Game>, IServiceAsync<Game>
    { }
}