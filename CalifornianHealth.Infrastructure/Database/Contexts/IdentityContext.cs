using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Contexts;

public class IdentityContext : IdentityDbContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        Patient.Configure(builder);
        base.OnModelCreating(builder);
    }

    public DbSet<Patient> Patients { get; set; }

}
