using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FooBackBar.DatabaseContext;
using FooBackBar.Services;
using FooBackBar.Services.BaseService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace FooBackBar
{
    public class Startup
    {
        private const string _defaultCors = "default";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IInfectionService, InfectionService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ICaseHistoryService, CaseHistoryService>();
            services.AddScoped<ICoordinatesService, CoordinatesService>();
            services.AddScoped<ICountryStatusService, CountryStatusService>();

            services.AddControllers();
            
            services.AddDbContext<Context>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(
              options => options.WithOrigins(configuration["AllowedOrigin"])
                .AllowAnyHeader()
                .AllowAnyMethod()
            );
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
