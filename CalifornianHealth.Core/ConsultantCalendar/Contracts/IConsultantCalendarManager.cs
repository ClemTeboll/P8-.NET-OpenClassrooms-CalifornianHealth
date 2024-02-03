using CalifornianHealth.Infrastructure.Database.Entities;

namespace CalifornianHealth.Core.ConsultantCalendar.Contracts
{
    public interface IConsultantCalendarManager
    {
        List<ConsultantCalendarOutputDto> GetAllConsultantCalendars();
        List<ConsultantCalendarOutputDto> GetConsultantCalendarsById(int id);
        int BookAppointment(AppointmentInputDto appointment);
    }
}
