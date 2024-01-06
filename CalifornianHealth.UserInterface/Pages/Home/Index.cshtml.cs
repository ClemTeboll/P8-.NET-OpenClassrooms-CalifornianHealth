using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CalifornianHealth.UserInterface.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        HttpClient _httpClient = new HttpClient();
        public List<ConsultantOutputDto> _consultantOutputDto;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            var result = await _httpClient.GetAsync("https://localhost:44332/api/Consultant");
            result.EnsureSuccessStatusCode();

            var data = await result.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            _consultantOutputDto = JsonSerializer.Deserialize<List<ConsultantOutputDto>>(data, options)!;
        }
    }
}