using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Services;

using FinalBoss.ObjectModel;
using FinalBoss.Database.Services;

namespace FinalBoss.Database.Sync
{
    internal class Program
    {
        private static readonly string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };

        private static IConfiguration Configuration;

        private static async Task Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("Default"));
                    });

                    services.AddScoped<IPlatformService, PlatformService>();
                })
                .Build();

            using var scope = host.Services
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            try
            {
                GoogleCredential credential;

                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential
                        .FromStream(stream)
                        .CreateScoped(Scopes);
                }

                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = Configuration.GetValue<string>("GoogleSheets:ApplicationName"),
                });

                TableImporter importer = new("1W-kxYa5LodM8cyyXzhzngv_a8wm8AaTXjXrcwvwYBSQ");

                await importer.ImportAsync<Platform, IPlatformService>(
                    service, "Platforms",
                    scope.ServiceProvider.GetRequiredService<IPlatformService>());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}