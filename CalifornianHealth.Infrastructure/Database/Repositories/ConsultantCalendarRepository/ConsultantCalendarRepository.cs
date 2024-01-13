using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository
{
    public class ConsultantCalendarRepository : IConsultantCalendarRepository
    {
        private readonly CalifornianHealthContext _dbContext;

        public ConsultantCalendarRepository(CalifornianHealthContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ConsultantCalendar> FetchConsultantCalendar(int id)
        {
            return _dbContext.ConsultantCalendars.Where(cc => cc.ConsultantId == id).ToList();
        }
    }
}
