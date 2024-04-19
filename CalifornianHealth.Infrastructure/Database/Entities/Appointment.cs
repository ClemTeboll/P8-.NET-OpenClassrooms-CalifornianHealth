using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CalifornianHealth.Infrastructure.Database.Entities;

public partial class Appointment
{
    public int Id { get; set; }
    [ConcurrencyCheck]
    public DateTime? StartDateTime { get; set; }
    [ConcurrencyCheck]
    public DateTime? EndDateTime { get; set; }
    [ConcurrencyCheck]
    public int? ConsultantId { get; set; }
    [ConcurrencyCheck]
    public string? PatientId { get; set; }

    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(c =>
        {
            c.HasKey(x => x.Id);
            c.ToTable(nameof(Appointment));
        });
    }
}
