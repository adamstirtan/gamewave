using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Serilog;
using Serilog.Events;

using FinalBoss.Api.Mapping;
using FinalBoss.Database;
using FinalBoss.Database.Services;

namespace FinalBoss.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString(_environment.EnvironmentName);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithThreadId()
                .Enrich.WithClientIp()
                .Enrich.WithClientAgent()
                .WriteTo.Console()
                .CreateLogger();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString(_environment.EnvironmentName), database =>
                {
                    database.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name);
                    database.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
            });

            var mapperConfiguration = AutoMapperConfiguration.Configure();

            services.AddAutoMapper(mapperConfiguration);

            services.AddScoped<IAgeRatingService, AgeRatingService>();
            services.AddScoped<IAgeRatingContentDescriptorService, AgeRatingContentDescriptorService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameEngineService, GameEngineService>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddSingleton(_environment.WebRootFileProvider);

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader());
            });

            services.AddControllers();
            services.AddHealthChecks();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Final Boss API",
                    Version = "v1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Final Boss API");
                options.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/status");
                endpoints.MapControllers();
            });
        }
    }
}