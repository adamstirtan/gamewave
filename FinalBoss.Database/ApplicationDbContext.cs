using System.Reflection;

using Microsoft.EntityFrameworkCore;

using FinalBoss.ObjectModel;
using FinalBoss.Database.Extensions;

namespace FinalBoss.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<GameEngine> GameEngines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }
    }
}