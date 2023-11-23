using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Repositories.AppointmentRepository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private DbSet<Appointment> _dbSet;
        public AppointmentRepository(DbSet<Appointment> dbSet)
        //: base(dbSet)
        {
            _dbSet = dbSet;
        }
    }
}
