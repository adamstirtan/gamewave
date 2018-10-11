using System.Collections.Generic;

using FinalBoss.Database.Entities;

namespace FinalBoss.Database.Repositories
{
    public interface IFinalBossRepository
    {
        IEnumerable<Game> GetAllGames();

        bool Save();
    }
}
