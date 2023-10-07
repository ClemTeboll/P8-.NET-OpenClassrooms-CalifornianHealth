using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalifornianHealth.Infrastructure.Database.Configuration;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplicationContext(this IServiceCollection services, string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            return services;

        return services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(connectionString, (o) => o.EnableRetryOnFailure());
        });
    }
}
