using MediatR;
using NestData.Configurations;
using NestData.Controllers;
using NestData.Core.Configurations;
using NestData.Core.Data;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace NestData;

public static class Configure
{
    private static Container _container;
    
    public static void ConfigureBuilder(WebApplicationBuilder builder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DataContext).Assembly);
        });
        builder.Services.AddSwaggerGen();
        
        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", true)
            .AddEnvironmentVariables()
            .Build();
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        
        DatabaseConfiguration.Configure(builder.Services, builder.Configuration);
    }

    public static void ConfigureApp(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            c.RoutePrefix = "swagger";
        });
        app.UseHttpsRedirection();
        app.MapControllers();
    }
}