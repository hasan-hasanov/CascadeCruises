using CQS_Demo.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Services.Configuration;

namespace CQS_Demo.Configurations
{
    public class AppConfigurations
    {
        public static void AddMvc(IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
                options.Filters.Add(typeof(GlobalExceptionHandlingFilter));
            })
            .AddApiExplorer()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public static void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Cascade Cruises",
                    License = new OpenApiLicense { Name = "Zeyneb Dzhelil" }
                });
            });
        }

        public static void AddMediatr(IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyResolver).Assembly);
        }

        public static void AddHttpContextAccessor(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }

        public static void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cascade Cruises");
            });
        }
    }
}