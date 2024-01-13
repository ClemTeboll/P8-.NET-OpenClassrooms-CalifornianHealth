namespace CalifornianHealth.Core.ConsultantCalendar.Contracts
{
    public interface IConsultantCalendarManager
    {
        IEnumerable<ConsultantCalendarOutputDto> GetConsultantCalendarsById(int id);
    }
}
