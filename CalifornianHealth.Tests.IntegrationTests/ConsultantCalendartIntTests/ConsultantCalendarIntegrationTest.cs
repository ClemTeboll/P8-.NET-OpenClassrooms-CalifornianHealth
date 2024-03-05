using CalifornianHealth.WebAPIs.Calendar.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CalifornianHealth.Tests.IntegrationTests.ConsultantCalendartIntTests;

public class ConsultantCalendarControllerTests
{
    private readonly WebApplicationFactory<ConsultantCalendarController> _factory;

    public ConsultantCalendarControllerTests()
    {
        _factory = new WebApplicationFactory<ConsultantCalendarController>();
    }

    [Fact]
    public async Task Get_ReturnsOkResult_WhenConsultantCalendarsExist()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/ConsultantCalendar");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var consultantCalendars = JsonConvert.DeserializeObject<List<ConsultantCalendarOutputDto>>(content);
        Assert.NotNull(consultantCalendars);
        Assert.NotEmpty(consultantCalendars);
    }

    [Fact]
    public async Task Get_ConsultantCalendarById_ReturnsNotFoundResponse()
    {
        // Arrange
        var client = _factory.CreateClient();
        var id = 10;

        // Act
        var response = await client.GetAsync($"/api/ConsultantCalendar/{id}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Post_Appointment_ReturnsOkResponse()
    {
        // Arrange
        var client = _factory.CreateClient();
        var appointmentInput = new AppointmentInputDto
        {
            Id = 1,
            StartDateTime = DateTime.Now,
            EndDateTime = DateTime.Now.AddHours(1),
            ConsultantId = 1,
            PatientId = 1
        };
        var json = JsonConvert.SerializeObject(appointmentInput);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/api/ConsultantCalendar", content);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var responseContent = await response.Content.ReadAsStringAsync();
        var createdAppointmentId = JsonConvert.DeserializeObject<int>(responseContent);

        Assert.NotEqual(0, createdAppointmentId);
    }

    [Fact]
    public async Task Post_Appointment_ReturnsBadRequestResponse()
    {
        // Arrange
        var client = _factory.CreateClient();
        var appointmentInput = new AppointmentInputDto
        {
            Id = 1,
            StartDateTime = DateTime.Now,
            EndDateTime = DateTime.Now.AddHours(1),
            ConsultantId = 1,
            PatientId = 1
        };
        var json = JsonConvert.SerializeObject(appointmentInput);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/api/ConsultantCalendar", content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
