using CalifornianHealth.Core.ConsultantCalendar.Contracts;
using CalifornianHealth.Infrastructure.Database.Entities;
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

        // GET: api/ConsultantCalendar
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
        public async Task<ActionResult<int>> Post([FromBody] AppointmentInputDto appointmentInput)
        {
            if (appointmentInput == null)
                return BadRequest("Invalid input");

            var createdAppointmentId = _manager.BookAppointment(appointmentInput);

            if (createdAppointmentId == 0)
                return BadRequest("Appointment not created");

            return Ok(createdAppointmentId);
        }
    }
}
