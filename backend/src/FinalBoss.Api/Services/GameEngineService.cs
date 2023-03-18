using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Services
{
    public sealed class GameEngineService : BaseService<GameEngine>, IGameEngineService
    {
        public GameEngineService(ApplicationDbContext context)
            : base(context)
        { }
    }
}