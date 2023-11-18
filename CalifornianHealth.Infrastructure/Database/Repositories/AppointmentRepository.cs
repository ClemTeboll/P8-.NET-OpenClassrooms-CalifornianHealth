using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Repositories
{
    public class AppointmentRepository
    {
        private DbSet<Appointment> _dbSet;
        public AppointmentRepository(DbSet<Appointment> dbSet)
        //: base(dbSet)
        {
            _dbSet = dbSet;
        }
    }
}
