using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Contexts;

public class IdentityContext : IdentityDbContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>();
    }
}
