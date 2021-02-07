using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Services
{
    public sealed class GameService : BaseService<Game>, IGameService
    {
        public GameService(ApplicationDbContext context)
            : base(context)
        { }
    }
}