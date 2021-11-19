using CQS_Demo.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Services.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appSettings.json", true);
builder.Configuration.AddEnvironmentVariables();

DependencyResolver.RegisterTypes(builder.Services, builder.Configuration);

AppConfigurations.AddControllers(builder.Services);
AppConfigurations.ConfigureSwaggerServices(builder.Services);
AppConfigurations.AddMediatr(builder.Services);
AppConfigurations.AddHttpContextAccessor(builder.Services);

var app = builder.Build();

AppConfigurations.ConfigureSwagger(app);

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();