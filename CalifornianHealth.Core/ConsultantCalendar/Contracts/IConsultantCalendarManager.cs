namespace CalifornianHealth.Core.ConsultantCalendar.Contracts
{
    public interface IConsultantCalendarManager
    {
        List<ConsultantCalendarOutputDto> GetAllConsultantCalendars();
        List<ConsultantCalendarOutputDto> GetConsultantCalendarsById(int id);
    }
}
