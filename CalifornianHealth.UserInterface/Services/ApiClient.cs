using System.Text.Json;

namespace CalifornianHealth.UserInterface.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ConsultantOutputDto>> GetAllConsultants()
        {
            var result = await _httpClient.GetAsync("https://localhost:44332/api/Consultant");
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
            var result = await _httpClient.GetAsync("https://localhost:44332/api/ConsultantCalendar");
            result.EnsureSuccessStatusCode();

            var data = await result.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<List<ConsultantCalendarOutputDto>>(data, options)!;
        }
    }
}
