using System.Collections.Generic;
using System.Linq;

using FinalBoss.Database.Entities;

namespace FinalBoss.Database.Repositories
{
    public class FinalBossRepository : IFinalBossRepository
    {
        private readonly ApplicationDbContext _context;

        public FinalBossRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games.OrderBy(x => x.Name).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
