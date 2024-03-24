using CalifornianHealth.Infrastructure.Database.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using Testcontainers.MsSql;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class, IAsyncLifetime
{
    private static readonly Lazy<MsSqlContainer> _msSqlContainer = new Lazy<MsSqlContainer>(() =>
    {
        return new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04")
            .WithPassword("Password123")
            .WithEnvironment("ACCEPT_EULA", "Y")
            .WithPortBinding(1433)
            .Build();
    });

    private MsSqlContainer MsSqlContainer => _msSqlContainer.Value;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<CalifornianHealthContext>));

            if (dbContextDescriptor is not null)
                services.Remove(dbContextDescriptor);

            services.AddDbContext<CalifornianHealthContext>(options =>
            {
                options
                    .UseSqlServer(MsSqlContainer.GetConnectionString());
            });
        });
    }

    public Task StartAsync()
    {
        return MsSqlContainer.StartAsync();
    }

    public Task StopAsync()
    {
        return MsSqlContainer.StopAsync();
    }
}