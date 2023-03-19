using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Services
{
    public sealed class GameService : BaseService<Game>, IGameService
    {
        public GameService(ApplicationDbContext context)
            : base(context)
        { }

        public override Game GetById(long id)
        {
            return Context.Games
                .Include(x => x.Developer)
                .FirstOrDefault(x => x.Id == id);
        }

        public override async Task<Game> GetByIdAsync(long id)
        {
            return await Context.Games
                .Include(x => x.Developer)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}