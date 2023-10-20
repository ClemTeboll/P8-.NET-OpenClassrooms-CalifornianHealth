using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalifornianHealth.UserInterface.Pages.Booking
{
    public class GetConsultantCalendarModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public GetConsultantCalendarModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Should get ConsultantModelList to return
            //var consultantCalendatList = GetAllConsultants();
        }
    }
}
