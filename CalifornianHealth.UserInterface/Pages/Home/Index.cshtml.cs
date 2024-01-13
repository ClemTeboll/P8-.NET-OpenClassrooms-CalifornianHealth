using CalifornianHealth.UserInterface.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            _consultantOutputDto = await _apiClient.GetAllConsultants();
        }
    }
}