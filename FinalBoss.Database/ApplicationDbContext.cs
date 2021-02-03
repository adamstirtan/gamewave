using Microsoft.EntityFrameworkCore;

using FinalBoss.ObjectModel;

namespace FinalBoss.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
    }
}