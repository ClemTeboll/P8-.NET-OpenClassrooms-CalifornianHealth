using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Repositories
{
    public class ConsultantCalendarRepository
    {
        private DbSet<ConsultantCalendar> _dbSet;

        public ConsultantCalendarRepository(DbSet<ConsultantCalendar> dbSet)
        {
            _dbSet = dbSet;
        }
    }
}
