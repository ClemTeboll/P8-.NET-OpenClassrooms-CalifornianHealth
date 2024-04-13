using CalifornianHealth.Core.ConsultantCalendar;
using CalifornianHealth.Infrastructure.Database.Entities;
using CalifornianHealth.Infrastructure.Database.Repositories.AppointmentRepository;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository;
using Moq;

namespace CalifornianHealth.Tests.UnitTests;

public class ConsultantCalendarManagerTests
{
    private readonly Mock<IConsultantCalendarRepository> _mockedConsultantCalendarRepository;
    private readonly Mock<IAppointmentRepository> _mockedAppointmentRepository;
    private readonly ConsultantCalendarManager _manager;

    public ConsultantCalendarManagerTests()
    {
        _mockedConsultantCalendarRepository = new Mock<IConsultantCalendarRepository>();
        _mockedAppointmentRepository = new Mock<IAppointmentRepository>();
        _manager = new ConsultantCalendarManager(_mockedConsultantCalendarRepository.Object, _mockedAppointmentRepository.Object);
    }

    [Fact]
    public void Should_Return_All_Consultant_Calendars()
    {
        // Arrange
        var consultantCalendars = new List<ConsultantCalendar>
        {
            new ConsultantCalendar 
            { 
                Id = 1, 
                ConsultantId = 1, 
                
                Date = DateTime.Now, Available = true 
            },
            new ConsultantCalendar 
            { 
                Id = 2, 
                ConsultantId = 2, 
                Date = DateTime.Now.AddDays(1), 
                Available = false
            }
        };

        _mockedConsultantCalendarRepository.Setup(repo => repo.FetchConsultantCalendar()).Returns(consultantCalendars);

        // Act
        var result = _manager.GetAllConsultantCalendars();

        // Assert
        Assert.Equal(consultantCalendars.Count, result.Count);
        _mockedConsultantCalendarRepository.Verify(repo => repo.FetchConsultantCalendar(), Times.Once);
    }

    [Fact]
    public void GetConsultantCalendarsById_ShouldReturnConsultantCalendarsWithGivenId()
    {
        // Arrange
        int testId = 1;
        var consultantCalendars = new List<ConsultantCalendar>
            {
                new() { Id = testId, ConsultantId = 1, Date = DateTime.Now, Available = true },
                new() { Id = testId, ConsultantId = 2, Date = DateTime.Now.AddDays(1), Available = false }
            };

        _mockedConsultantCalendarRepository.Setup(repo => repo.FetchConsultantCalendarById(testId)).Returns(consultantCalendars);

        // Act
        var result = _manager.GetConsultantCalendarsById(testId);

        // Assert
        Assert.Equal(testId, result[0].Id);
        _mockedConsultantCalendarRepository.Verify(repo => repo.FetchConsultantCalendarById(testId), Times.Once);
    }

    [Fact]
    public void BookAppointment_ShouldBookAppointmentSuccessfully()
    {
        // Arrange
        var appointmentInput = new AppointmentInputDto
        {
            ConsultantId = 1,
            StartDateTime = DateTime.Now,
            EndDateTime = DateTime.Now.AddHours(1),
            PatientId = 1
        };

        var consultantCalendar = new ConsultantCalendar
        {
            Id = appointmentInput.Id,
            ConsultantId = appointmentInput.ConsultantId,
            Date = DateTime.Now,
            Available = true
        };

        _mockedConsultantCalendarRepository.Setup(repo => repo.FetchConsultantCalendarById(appointmentInput.ConsultantId)).Returns(new List<ConsultantCalendar> { consultantCalendar });
        _mockedAppointmentRepository.Setup(repo => repo.CreateAppointment(It.IsAny<Appointment>())).Returns(1);

        // Act
        var result = _manager.BookAppointment(appointmentInput);

        // Assert
        Assert.Equal(1, result);
        _mockedConsultantCalendarRepository.Verify(repo => repo.FetchConsultantCalendarById(appointmentInput.ConsultantId), Times.Once);
        _mockedConsultantCalendarRepository.Verify(repo => repo.UpdateConsultantCalendar(It.IsAny<ConsultantCalendar>()), Times.Once);
        _mockedAppointmentRepository.Verify(repo => repo.CreateAppointment(It.IsAny<Appointment>()), Times.Once);
    }
}
