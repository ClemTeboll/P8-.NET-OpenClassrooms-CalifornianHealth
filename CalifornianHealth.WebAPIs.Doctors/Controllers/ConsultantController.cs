using Microsoft.AspNetCore.Mvc;

namespace CalifornianHealth.WebAPIs.Doctors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        // GET: api/<ConsultantController>
        [HttpGet]
        public IEnumerable<ConsultantDto> Get()
        {
            return new List<ConsultantDto>();
        }

        // GET api/<ConsultantController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConsultantController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConsultantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConsultantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
