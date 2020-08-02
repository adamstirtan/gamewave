using Microsoft.EntityFrameworkCore;

using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Database
{
    public class FinalBossContext : DbContext
    {
        public FinalBossContext(DbContextOptions<FinalBossContext> context)
            : base(context)
        { }

        public DbSet<Game> Games { get; set; }
    }
}
