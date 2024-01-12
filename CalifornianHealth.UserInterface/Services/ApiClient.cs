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

        //public async Task<List<ConsultantOutputDto>> GetConsultantById(int id)
        //{
        //    var result = await _httpClient.GetAsync($"https://localhost:44332/api/Consultant/{id}");
        //    result.EnsureSuccessStatusCode();

        //    var data = await result.Content.ReadAsStreamAsync();
        //    var options = new JsonSerializerOptions()
        //    {
        //        PropertyNameCaseInsensitive = true,
        //    };

        //    return JsonSerializer.Deserialize<List<ConsultantOutputDto>>(data, options)!;
        //}

        //public async Task<List<ConsultantOutputDto>> GetConsultantBySpeciality(string speciality)
        //{
        //    var result = await _httpClient.GetAsync($"https://localhost:44332/api/Consultant/{speciality}");
        //    result.EnsureSuccessStatusCode();

        //    var data = await result.Content.ReadAsStreamAsync();
        //    var options = new JsonSerializerOptions()
        //    {
        //        PropertyNameCaseInsensitive = true,
        //    };

        //    return JsonSerializer.Deserialize<List<ConsultantOutputDto>>(data, options)!;
        //}

        //public async Task<List<ConsultantOutputDto>> GetConsultantByAvailability(DateTime availability)
        //{
        //    var result = await _httpClient.GetAsync($"https://localhost:44332/api/Consultant/{availability}");
        //    result.EnsureSuccessStatusCode();

        //    var data = await result.Content.ReadAsStreamAsync();
        //    var options = new JsonSerializerOptions()
        //    {
        //        PropertyNameCaseInsensitive = true,
        //    };

        //    return JsonSerializer.Deserialize<List<ConsultantOutputDto>>(data, options)!;
        //}

        //public async Task<List<ConsultantOutputDto>> GetConsultantByAvailabilityAndSpeciality(DateTime availability, string speciality)
        //{
        //    var result = await _httpClient.GetAsync($"https://localhost:44332/api/Consultant/{availability}/{speciality}");
        //    result.EnsureSuccessStatusCode();

        //    var data = await result.Content.ReadAsStreamAsync();
        //    var options = new JsonSerializerOptions()
        //    { };
        //}
    }
}
