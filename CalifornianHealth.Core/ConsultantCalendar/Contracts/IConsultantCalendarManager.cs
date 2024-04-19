namespace CalifornianHealth.Core.ConsultantCalendar.Contracts;

public interface IConsultantCalendarManager
{
    List<ConsultantCalendarOutputDto> GetAllConsultantCalendars();
    ConsultantCalendarOutputDto GetConsultantCalendarsById(int id);
    int BookAppointment(AppointmentInputDto appointment);
}
