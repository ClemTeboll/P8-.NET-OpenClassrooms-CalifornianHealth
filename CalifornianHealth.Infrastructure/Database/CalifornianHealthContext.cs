using CalifornianHealth.Infrastructure.Database.Entities;
using CalifornianHealth.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database
{
    public class CalifornianHealthContext : DbContext
    {
        public CalifornianHealthContext(DbContextOptions<CalifornianHealthContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Consultant.Configure(modelBuilder);
            ConsultantCalendar.Configure(modelBuilder);
            Appointment.Configure(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }

        public ConsultantRepository ConsultantRepository => new(Set<Consultant>());

        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<ConsultantCalendar> ConsultantCalendars { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
