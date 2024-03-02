using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CalifornianHealth.Infrastructure.Database.Contexts;

public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityContext>
{
    public IdentityContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\CalifornianHealth.WebAPIs.Calendar");
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<IdentityContext>();

        var connectionString = configuration.GetConnectionString("ApplicationConnection");

        builder.UseSqlServer(connectionString);

        return new IdentityContext(builder.Options);
    }
}
