using System.Text.Json;

namespace CalifornianHealth.UserInterface.Services;

public class ApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ApiClient(HttpClient httpClient, IWebHostEnvironment env)
    {
        _httpClient = httpClient;
        _baseUrl = GetBaseUrl(env);
    }

    private static string GetBaseUrl(IWebHostEnvironment env)
    {
        return env.IsDevelopment() ? "http://host.docker.internal:5013" : "https://host.docker.internal:7090";
    }

    public async Task<List<ConsultantOutputDto>> GetAllConsultants()
    {
        var result = await _httpClient.GetAsync($"{_baseUrl}/api/Consultant");
        result.EnsureSuccessStatusCode();

        var data = await result.Content.ReadAsStreamAsync();
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };

        return JsonSerializer.Deserialize<List<ConsultantOutputDto>>(data, options)!;
    }

    public async Task<List<ConsultantCalendarOutputDto>> GetAllConsultantCalendars()
    {
        var result = await _httpClient.GetAsync($"{_baseUrl}/api/ConsultantCalendar");

        result.EnsureSuccessStatusCode();

        var data = await result.Content.ReadAsStreamAsync();
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };

        return JsonSerializer.Deserialize<List<ConsultantCalendarOutputDto>>(data, options)!;
    }
}
