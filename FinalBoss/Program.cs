using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using FinalBoss.Database;

namespace FinalBoss
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            SeedDatabase(host);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration(SetupConfiguration)
               .UseStartup<Startup>()
               .Build();
        
        private static void SetupConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();

            builder
                .AddJsonFile("config.json", false, true)
                .AddEnvironmentVariables();
        }

        private static void SeedDatabase(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seed = scope.ServiceProvider.GetService<ApplicationDbContextSeed>();

                seed.Seed();
            }
        }
    }
}
