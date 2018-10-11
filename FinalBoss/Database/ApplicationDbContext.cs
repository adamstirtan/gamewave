using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using FinalBoss.Database.Entities;

namespace FinalBoss.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Video> Videos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
    }
}
