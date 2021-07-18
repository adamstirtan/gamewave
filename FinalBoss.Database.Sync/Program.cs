using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace FinalBoss.Database.Sync
{
    // Based on https://developers.google.com/sheets/api/quickstart/dotnet
    internal class Program
    {
        private static readonly string ApplicationName = "Final Boss Sync";
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
                })
                .Build();

            using var scope = host.Services
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            try
            {
                var memoryStream = new MemoryStream();
                var writer = new StreamWriter(memoryStream);

                string googleSheetsCredentials = Configuration.GetSection("GoogleSheets").Value;

                writer.Write(googleSheetsCredentials);
                writer.Flush();

                memoryStream.Position = 0;

                UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(memoryStream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore("token.json", true)); // needed?

                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                string spreadsheetId = "1W-kxYa5LodM8cyyXzhzngv_a8wm8AaTXjXrcwvwYBSQ";
                string range = "Games!A2:E";
                SpreadsheetsResource.ValuesResource.GetRequest request =
                        service.Spreadsheets.Values.Get(spreadsheetId, range);

                ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;

                if (values != null && values.Count > 0)
                {
                    Console.WriteLine("Name, Major");
                    foreach (var row in values)
                    {
                        // Print columns A and E, which correspond to indices 0 and 4.
                        Console.WriteLine("{0}, {1}", row[0], row[4]);
                    }
                }
                else
                {
                    Console.WriteLine("No data found");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}