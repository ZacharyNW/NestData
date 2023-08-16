using NestData.Core.Configurations;
using NestData.Core.Data;

namespace NestData.Configurations;

public class DatabaseConfiguration
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(o => DatabaseCoreConfiguration.ApplyDbContextOptions(o, configuration));
    }
}