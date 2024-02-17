using CalifornianHealth.UserInterface.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalifornianHealth.UserInterface.Pages.Booking
{
    public class GetConsultantCalendarModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ApiClient _apiClient;
        public List<ConsultantOutputDto> _consultantOutputDto;

        public GetConsultantCalendarModel(ILogger<IndexModel> logger, ApiClient apiClient, List<ConsultantOutputDto> consultantOutputDto)
        {
            _logger = logger;
            _apiClient = apiClient;
            _consultantOutputDto = consultantOutputDto;
        }

        public async Task OnGet()
        {
            _consultantOutputDto = await _apiClient.GetAllConsultants();
        }
    }
}
