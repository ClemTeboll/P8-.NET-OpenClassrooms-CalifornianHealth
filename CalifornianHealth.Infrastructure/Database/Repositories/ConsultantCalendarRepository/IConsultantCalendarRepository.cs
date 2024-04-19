using CalifornianHealth.Infrastructure.Database.Entities;

namespace CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository;

public interface IConsultantCalendarRepository
{
    IEnumerable<ConsultantCalendar> FetchConsultantCalendar();
    IEnumerable<ConsultantCalendar> FetchConsultantCalendarsByConsultantId(int id);
    ConsultantCalendar FetchOneConsultantCalendarById(int id);
    int UpdateConsultantCalendar(ConsultantCalendar consultantCalendar);
}
