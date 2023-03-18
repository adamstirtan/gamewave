using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Services
{
    public sealed class GameService : BaseService<Game>, IGameService
    {
        public GameService(ApplicationDbContext context)
            : base(context)
        { }
    }
}