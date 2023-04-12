using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using GameWave.ObjectModel;

namespace GameWave.Api.Services
{
    public sealed class GameService : BaseService<Game>, IGameService
    {
        public GameService(ApplicationDbContext context)
            : base(context)
        { }

        public override IQueryable<Game> All()
        {
            return Set
                .Include(x => x.Developer)
                .Include(x => x.Publisher);
        }

        public override Game GetById(long id)
        {
            return Context.Games
                .Include(x => x.Developer)
                .Include(x => x.Publisher)
                .FirstOrDefault(x => x.Id == id);
        }

        public override async Task<Game> GetByIdAsync(long id)
        {
            return await Context.Games
                .Include(x => x.Developer)
                .Include(x => x.Publisher)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}