using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Services
{
    public sealed class GameEngineService : BaseService<GameEngine>, IGameEngineService
    {
        public GameEngineService(ApplicationDbContext context)
            : base(context)
        { }
    }
}