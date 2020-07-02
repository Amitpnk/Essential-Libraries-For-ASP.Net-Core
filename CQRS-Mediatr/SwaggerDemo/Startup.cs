using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SwaggerDemo.Data;
using System;
using System.IO;
using System.Reflection;

namespace SwaggerDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "URL is static")]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(setupAction =>
             {
                 setupAction.Filters.Add(
                        new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                 setupAction.Filters.Add(
                        new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                 setupAction.Filters.Add(
                        new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                 setupAction.Filters.Add(
                        new ProducesDefaultResponseTypeAttribute());
             });

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<ApplicationContext>(opt =>
                 //opt.UseInMemoryDatabase("InMemoryCustomerDB")
                 opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                 //b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)
                 ));



            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "OpenAPISpecificationCustomer",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Customer API",
                        Version = "1",
                        Description = "Through this API you can access customer details",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "amit.naik8103@gmail.com",
                            Name = "Amit Naik",
                            Url = new Uri("https://amitpnk.github.io/")
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }
                    });

                setupAction.SwaggerDoc(
                  "OpenAPISpecificationWeatherDefault",
                  new Microsoft.OpenApi.Models.OpenApiInfo()
                  {
                      Title = "Weather default API",
                      Version = "1",
                      Description = "Through this API you can access customer details",
                      Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                      {
                          Email = "amit.naik8103@gmail.com",
                          Name = "Amit Naik",
                          Url = new Uri("https://amitpnk.github.io/")
                      },
                      License = new Microsoft.OpenApi.Models.OpenApiLicense()
                      {
                          Name = "MIT License",
                          Url = new Uri("https://opensource.org/licenses/MIT")
                      }
                  });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
               {
                   setupAction.SwaggerEndpoint("/swagger/OpenAPISpecificationCustomer/swagger.json", "Customer API");
                   setupAction.SwaggerEndpoint("/swagger/OpenAPISpecificationWeatherDefault/swagger.json", "Weather default API");

                   setupAction.RoutePrefix = string.Empty;
               });
        }
    }
}
