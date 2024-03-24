using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;

namespace CalifornianHealth.Tests.IntegrationTests.CalendarIntTests;

public abstract class CalendarIntTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly IServiceScope _scope;
    protected readonly HttpClient _client;

    public CalendarIntTests(CustomWebApplicationFactory<Program> factory)
    {
        _scope = factory.Services.CreateScope();
        _client = _scope.ServiceProvider.GetRequiredService<HttpClient>();
    }

    [Fact]
    public async Task GetAllConsultants_ReturnsSuccessCode()
    {
        // Arrange
        var request = "https://host.docker.internal:5234/api/ConsultantCalendar";

        // Act
        var response = await _client.GetAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetConsultantCalendarById_ReturnsSuccessCode()
    {
        // Arrange
        var id = 1;
        var request = $"https://host.docker.internal:5234/api/ConsultantCalendar/{id}";

        // Act
        var response = await _client.GetAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task PostAppointment_ReturnsSuccessCode()
    {
        // Arrange
        var request = "https://host.docker.internal:5234/api/ConsultantCalendar";
        DateTime startDateTime = DateTime.Now;
        DateTime endDateTime = Convert.ToDateTime(Convert.ToInt32(startDateTime) + 60 * 60 * 1000);
        var appointmentInput = new AppointmentInputDto(1, startDateTime, endDateTime, 1, 1);

        // Act
        var response = await _client.PostAsJsonAsync(request, appointmentInput);

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
