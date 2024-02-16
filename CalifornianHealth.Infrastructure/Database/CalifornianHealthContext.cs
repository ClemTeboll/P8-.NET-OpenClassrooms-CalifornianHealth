using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database;

public class CalifornianHealthContext : DbContext
{
    public CalifornianHealthContext(DbContextOptions<CalifornianHealthContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Consultant.Configure(modelBuilder);
        ConsultantCalendar.Configure(modelBuilder);
        Appointment.Configure(modelBuilder);
        Patient.Configure(modelBuilder);
    }

    public DbSet<Consultant> Consultants { get; set; }
    public DbSet<ConsultantCalendar> ConsultantCalendars { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}
