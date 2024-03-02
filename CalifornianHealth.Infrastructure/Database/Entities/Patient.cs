using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Entities;

public partial class Patient : IdentityUser
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Postcode { get; set; } = string.Empty;

    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(c =>
        {
            c.HasKey(x => x.Id);
            c.Property(x => x.FirstName).HasMaxLength(50);
            c.Property(x => x.LastName).HasMaxLength(50);
            c.Property(x => x.Address1).HasMaxLength(255);
            c.Property(x => x.Address2).HasMaxLength(255);
            c.Property(x => x.City).HasMaxLength(50);
            c.Property(x => x.Postcode).HasMaxLength(10);
            c.ToTable(nameof(Patient));
        });
    }
}
