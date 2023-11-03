using CalifornianHealth.Core.Consultant;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            //ConsultantManager.ListConsultant();
            ConsultantDto consultant = new ConsultantDto("a", "b", "c");
            List<ConsultantDto> list = new List<ConsultantDto>();
            list.Add(consultant);
            return list;
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
