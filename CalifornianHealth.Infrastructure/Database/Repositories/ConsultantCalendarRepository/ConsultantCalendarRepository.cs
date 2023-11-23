using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository
{
    public class ConsultantCalendarRepository : IConsultantCalendarRepository
    {
        private DbSet<ConsultantCalendar> _dbSet;

        public ConsultantCalendarRepository(DbSet<ConsultantCalendar> dbSet)
        {
            _dbSet = dbSet;
        }
    }
}
