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
            new()
            {
                Id = 1,
                ConsultantId = 1,

                Date = DateTime.Now, Available = true
            },
            new()
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
        List<ConsultantCalendar> consultantCalendars = new()
        {
            new()
            {
                Id = testId,
                ConsultantId = 1,
                Date = DateTime.Now,
                Available = true
            }
        };
            

        _mockedConsultantCalendarRepository.Setup(repo => repo.FetchConsultantCalendarsByConsultantId(testId)).Returns(consultantCalendars);

        // Act
        var result = _manager.GetAllConsultantCalendarsByConsultantId(testId);

        // Assert
        Assert.Equal(testId, result[0].Id);
        _mockedConsultantCalendarRepository.Verify(repo => repo.FetchConsultantCalendarsByConsultantId(testId), Times.Once);
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
            PatientId = "V3ryC0mpl1C@tedHa$h"
        };

        var consultantCalendar = new ConsultantCalendar
        {
            Id = appointmentInput.Id,
            ConsultantId = appointmentInput.ConsultantId,
            Date = DateTime.Now,
            Available = true
        };

        _mockedConsultantCalendarRepository.Setup(repo => repo.FetchOneConsultantCalendarById(appointmentInput.ConsultantId)).Returns(consultantCalendar);
        _mockedAppointmentRepository.Setup(repo => repo.CreateAppointment(It.IsAny<Appointment>())).Returns(1);

        // Act
        var result = _manager.BookAppointment(appointmentInput);

        // Assert
        Assert.Equal(1, result);
        _mockedConsultantCalendarRepository.Verify(repo => repo.FetchOneConsultantCalendarById(appointmentInput.ConsultantId), Times.Once);
        _mockedConsultantCalendarRepository.Verify(repo => repo.UpdateConsultantCalendar(It.IsAny<ConsultantCalendar>()), Times.Once);
        _mockedAppointmentRepository.Verify(repo => repo.CreateAppointment(It.IsAny<Appointment>()), Times.Once);
    }
}
