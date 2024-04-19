using CalifornianHealth.Core.ConsultantCalendar.Contracts;
using CalifornianHealth.Infrastructure.Database.Entities;
using CalifornianHealth.Infrastructure.Database.Repositories.AppointmentRepository;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository;

namespace CalifornianHealth.Core.ConsultantCalendar;

public class ConsultantCalendarManager : IConsultantCalendarManager
{
    private readonly IConsultantCalendarRepository _consultantCalendarRepository;
    private readonly IAppointmentRepository _appointmentRepository;

    public ConsultantCalendarManager(IConsultantCalendarRepository consultantCalendarRepository, IAppointmentRepository appointmentRepository)
    {
        _consultantCalendarRepository = consultantCalendarRepository;
        _appointmentRepository = appointmentRepository;
    }

    public List<ConsultantCalendarOutputDto> GetAllConsultantCalendars()
    {
        var request = _consultantCalendarRepository.FetchConsultantCalendar();

        return CreateOutputList(request);
    }

    public List<ConsultantCalendarOutputDto> GetAllConsultantCalendarsByConsultantId(int id)
    {
        var request = _consultantCalendarRepository.FetchConsultantCalendarsByConsultantId(id).Where(x => x.Available);

        return CreateOutputList(request);
    }

    public int BookAppointment(AppointmentInputDto appointmentInput)
    {
        var consultantCalendar = _consultantCalendarRepository.FetchOneConsultantCalendarById(appointmentInput.ConsultantId);

        if (consultantCalendar == null || !consultantCalendar.Available)
            throw new Exception("Consultant not available on this date");

        consultantCalendar.Available = false;

        _consultantCalendarRepository.UpdateConsultantCalendar(consultantCalendar);

        var appointment = new Appointment
        {
            ConsultantId = appointmentInput.ConsultantId,
            StartDateTime = appointmentInput.StartDateTime,
            EndDateTime = appointmentInput.EndDateTime,
            PatientId = appointmentInput.PatientId
        };

        return _appointmentRepository.CreateAppointment(appointment);
    }


    private static List<ConsultantCalendarOutputDto> CreateOutputList(IEnumerable<Infrastructure.Database.Entities.ConsultantCalendar> request)
    {
        return request.Select(x => new ConsultantCalendarOutputDto
        {
            Id = x.Id,
            ConsultantId = x.ConsultantId,
            Date = x.Date,
            Available = x.Available
        }).ToList();
    }
}
