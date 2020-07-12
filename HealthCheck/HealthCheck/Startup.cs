using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCheck.Data;
using HealthCheck.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HealthCheck
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

            services.AddHealthChecks()
                 .AddDbContextCheck<DataContext>(name: "DB context", failureStatus: HealthStatus.Degraded)
                 .AddUrlGroup(new Uri("https://amitpnk.github.io/"), name: "My personal website", failureStatus: HealthStatus.Degraded)
                 .AddCheck<CustomHealthCheck>(name: "New Custom Check", failureStatus: HealthStatus.Degraded)
                 .AddSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("Basic Health Check", $"http://localhost:55691/healthz");
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseHealthChecks("/healthz", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
                },
            })
               .UseHealthChecksUI(setup =>
               {
                   setup.ApiPath = "/healthcheck";
                   setup.UIPath = "/healthcheck-ui";
                   setup.AddCustomStylesheet("./Customization/custom.css");
               });



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
