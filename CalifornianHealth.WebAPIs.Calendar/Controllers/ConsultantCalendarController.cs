using CalifornianHealth.Core.ConsultantCalendar.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CalifornianHealth.WebAPIs.Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantCalendarController : ControllerBase
    {
        private readonly IConsultantCalendarManager _manager;

        public ConsultantCalendarController(IConsultantCalendarManager manager)
        {
            _manager = manager;
        }

        // GET: api/<ConsultantCalendarController>
        [HttpGet]
        public async Task<ActionResult<List<ConsultantCalendarOutputDto>>> Get()
        {
            var consultantCalendarList = _manager.GetAllConsultantCalendars();

            if (consultantCalendarList == null)
                return NotFound("No consultant calendars found");

            return Ok(consultantCalendarList);
        }

        // GET api/<ConsultantCalendarController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultantCalendarOutputDto>> Get(int id)
        {
            var consultantCalendar = _manager.GetConsultantCalendarsById(id);

            if (consultantCalendar == null)
                return NotFound("No consultant calendars found");

            return Ok(consultantCalendar);
        }

        // POST api/<ConsultantCalendarController>
        [HttpPost]
        public void Post([FromBody] int id)
        {
        }
    }
}
