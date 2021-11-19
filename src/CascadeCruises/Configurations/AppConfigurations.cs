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
        public static void AddControllers(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
                options.Filters.Add(typeof(GlobalExceptionHandlingFilter));
            });
        }

        public static void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setupAction =>
           {
               setupAction.SwaggerDoc("v1", new OpenApiInfo()
               {
                   Title = "Cascade Cruises",
                   License = new OpenApiLicense { Name = "Hasan Hasanov" }
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