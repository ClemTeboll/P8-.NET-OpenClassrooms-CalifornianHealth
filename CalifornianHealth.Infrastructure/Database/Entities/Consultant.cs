using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Entities
{
    public partial class Consultant
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Speciality { get; set; }

        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultant>(c =>
            {
                c.HasKey(x => x.Id);
                c.Property(x => x.FirstName).HasMaxLength(100);
                c.Property(x => x.LastName).HasMaxLength(100);
                c.Property(x => x.Speciality).HasMaxLength(50);
                c.ToTable(nameof(Consultant));
            });
        }

    }
}
