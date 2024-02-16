using CalifornianHealth.Infrastructure.Database.Entities;

namespace CalifornianHealth.Infrastructure.Database.Repositories.AppointmentRepository;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly CalifornianHealthContext _dbContext;

    public AppointmentRepository(CalifornianHealthContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int CreateAppointment(Appointment appointment) => _dbContext.Appointments.Add(appointment).Entity.Id;
}
