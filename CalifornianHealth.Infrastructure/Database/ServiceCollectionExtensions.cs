using CalifornianHealth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace CalifornianHealth.Infrastructure.Database;

public static class ServiceCollectionExtensions
{
    

    public static IServiceCollection AddCalifornianHealthContext(this IServiceCollection services, string connectionString = "Server=localhost;Database=P8_OC_CalifornianHealth;Trusted_Connection=true;TrustServerCertificate=true;")
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