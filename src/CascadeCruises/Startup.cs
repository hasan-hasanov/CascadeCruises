using CQS_Demo.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Configuration;

namespace CQS_Demo
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", optional: true)
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            DependencyResolver.RegisterTypes(services, _configuration);

            AppConfigurations.AddMvc(services);
            AppConfigurations.ConfigureSwaggerServices(services);
            AppConfigurations.AddMediatr(services);
            AppConfigurations.AddHttpContextAccessor(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AppConfigurations.ConfigureSwagger(app);

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
