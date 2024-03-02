using CalifornianHealth.Core.ConsultantCalendar.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CalifornianHealth.WebAPIs.Calendar.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultantCalendarController : ControllerBase
{
    private readonly IConsultantCalendarManager _manager;
    private static Semaphore _pool;
    private static int _padding;

    public ConsultantCalendarController(IConsultantCalendarManager manager, Semaphore pool)
    {
        _manager = manager;
        _pool = pool;
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
        _pool = new Semaphore(initialCount: 0, maximumCount: 1);

        //for (int i = 1; i <= 5; i++)
        //{
        //    Thread t = new Thread(new ParameterizedThreadStart(Worker));
        //    t.Start(i);
        //}

        var createdAppointmentId = _manager.BookAppointment(appointmentInput);

        if (createdAppointmentId == 0)
            return BadRequest("Appointment not created");

        _pool.Release(releaseCount: 1);

        return Ok(createdAppointmentId);
    }

    private static void Worker(object num)
    {
        _pool.WaitOne();

        int padding = Interlocked.Add(ref _padding, 100);

        Thread.Sleep(1000 + padding);
    }
}
