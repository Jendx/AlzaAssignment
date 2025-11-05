using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions;

public static class ContextRegistration
{
    public static IServiceCollection UseDataMsSql(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION");
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);
        
        // In case the api is running in docker. We need to use host specified in docker.yml
        var sqlServerHost = Environment.GetEnvironmentVariable("SQL_HOST");
        if (sqlServerHost is not null or { Length: 0 })
        {
            connectionString = connectionString.Replace("localhost", sqlServerHost);
        }
        
        services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(connectionString));
        
        return services;
    }
}