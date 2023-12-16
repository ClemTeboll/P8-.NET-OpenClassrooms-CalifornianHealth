using CalifornianHealth.Core.Consultant.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CalifornianHealth.WebAPIs.Doctors.Controllers
{
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
            var consultantList = await _manager.ListConsultants();

            if (consultantList == null)
                return NotFound("No consultants found");

            return Ok(consultantList);
        }

        //// GET api/<ConsultantController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ConsultantController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ConsultantController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ConsultantController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
