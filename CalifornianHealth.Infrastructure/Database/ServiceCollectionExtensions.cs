using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CalifornianHealth.Infrastructure.Database;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCalifornianHealthContext(this IServiceCollection services, string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            return services;

        return services.AddDbContext<CalifornianHealthContext>(options =>
        {
            options.UseSqlServer(connectionString, (o) => o.EnableRetryOnFailure());
            options.EnableSensitiveDataLogging(true);
        });
    }
}