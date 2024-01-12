using CalifornianHealth.UserInterface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CalifornianHealth.UserInterface.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ApiClient _apiClient;
        public List<ConsultantOutputDto> _consultantOutputDto;

        public IndexModel(ILogger<IndexModel> logger, ApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task OnGet()
        {
            //var result = await _httpClient.GetAsync("https://localhost:44332/api/Consultant");
            //result.EnsureSuccessStatusCode();

            //var data = await result.Content.ReadAsStreamAsync();
            //var options = new JsonSerializerOptions()
            //{
            //    PropertyNameCaseInsensitive = true,
            //};

            //_consultantOutputDto = JsonSerializer.Deserialize<List<ConsultantOutputDto>>(data, options)!;
            _consultantOutputDto = await _apiClient.GetAllConsultants();
        }
    }
}