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

        public DbSet<AgeRating> AgeRatings { get; set; }
        public DbSet<AgeRatingContentDescriptor> AgeRatingContentDescriptors { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameEngine> GameEngines { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }
    }
}