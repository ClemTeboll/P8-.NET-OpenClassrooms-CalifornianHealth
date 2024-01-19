using CalifornianHealth.Infrastructure.Database.Entities;

namespace CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository
{
    public class ConsultantCalendarRepository : IConsultantCalendarRepository
    {
        private readonly CalifornianHealthContext _dbContext;

        public ConsultantCalendarRepository(CalifornianHealthContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ConsultantCalendar> FetchConsultantCalendar()
        {
            return _dbContext.ConsultantCalendars.ToList();
        }

        public IEnumerable<ConsultantCalendar> FetchConsultantCalendarById(int id)
        {
            return _dbContext.ConsultantCalendars.Where(cc => cc.ConsultantId == id).ToList();
        }
    }
}
