using CalifornianHealth.Core.Consultant.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CalifornianHealth.WebAPIs.Doctors.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultantController : ControllerBase
{
    private readonly IConsultantManager _manager;

    public ConsultantController(IConsultantManager manager)
    {
        _manager = manager;
    }

    // GET: api/<ConsultantController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConsultantOutputDto>>> Get()
    {
        var consultantList = _manager.ListConsultants();

        if (consultantList == null)
            return NotFound("No consultants found");

        return Ok(consultantList);
    }
}
