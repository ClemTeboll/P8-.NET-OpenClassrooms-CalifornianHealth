using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Entities;

public partial class Appointment
{
    public int Id { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public int? ConsultantId { get; set; }
    public int? PatientId { get; set; }

    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(c =>
        {
            c.HasKey(x => x.Id);
            c.ToTable(nameof(Appointment));
        });
    }
}
