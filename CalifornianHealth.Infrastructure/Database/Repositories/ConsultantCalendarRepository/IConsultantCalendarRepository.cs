using CalifornianHealth.Infrastructure.Database.Entities;

namespace CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository;

public interface IConsultantCalendarRepository
{
    IEnumerable<ConsultantCalendar> FetchConsultantCalendar();
    IEnumerable<ConsultantCalendar> FetchConsultantCalendarById(int id);
    int UpdateConsultantCalendar(ConsultantCalendar consultantCalendar);
}
