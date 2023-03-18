using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using FinalBoss.ObjectModel;

namespace FinalBoss.Api
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Game> Games { get; set; }

        public DbSet<Platform> Platforms { get; set; }
    }
}