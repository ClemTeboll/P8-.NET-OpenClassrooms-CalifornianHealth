using CalifornianHealth.UserInterface.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalifornianHealth.UserInterface.Pages.Booking
{
    public class GetConsultantCalendarModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ApiClient _apiClient;
        public List<ConsultantOutputDto> _consultantOutputDto;

        public GetConsultantCalendarModel(ILogger<IndexModel> logger, ApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task OnGet()
        {
            // Should get ConsultantModelList to return
            //var consultantCalendatList = GetAllConsultants();
            _consultantOutputDto = await _apiClient.GetAllConsultants();
        }
    }
}
