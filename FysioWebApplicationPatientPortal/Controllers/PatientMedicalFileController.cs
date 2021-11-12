using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FysioWebApplicationPatientPortal.Controllers
{
    [Authorize]
    [Route("patient/[controller]")]
    [ApiController]
    public class PatientMedicalFileController : Controller
    {
        // GET: api/<PatientMedicalFile>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PatientMedicalFile>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PatientMedicalFile>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PatientMedicalFile>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientMedicalFile>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
