using CalifornianHealth.Infrastructure.Database.Entities;

namespace CalifornianHealth.Infrastructure.Database.Repositories.AppointmentRepository
{
    public interface IAppointmentRepository
    {
        int CreateAppointment(Appointment appointment);
    }
}
