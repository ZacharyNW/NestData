using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using NestData.Core.Data;

namespace NestData.Core.Configurations;

public class DatabaseCoreConfiguration
{
    public static void ConfigureCore()
    {
    }

    public static void ApplyDbContextOptions(DbContextOptionsBuilder dbContextOptionsBuilder,
        IConfiguration configuration)
    {
        dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString(nameof(DataContext)),
                sqlOptionsBuilder =>
                {
                    sqlOptionsBuilder.MigrationsAssembly(typeof(DataContext).Assembly.FullName);
                    sqlOptionsBuilder.MigrationsHistoryTable("MigrationHistory", "system");
                })
            .ConfigureWarnings(warnings =>
            {
                warnings.Log(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning);
            });
    }
}