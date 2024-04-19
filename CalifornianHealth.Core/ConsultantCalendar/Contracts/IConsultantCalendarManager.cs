namespace CalifornianHealth.Core.ConsultantCalendar.Contracts;

public interface IConsultantCalendarManager
{
    List<ConsultantCalendarOutputDto> GetAllConsultantCalendars();
    List<ConsultantCalendarOutputDto> GetAllConsultantCalendarsByConsultantId(int id);
    int BookAppointment(AppointmentInputDto appointment);
}
