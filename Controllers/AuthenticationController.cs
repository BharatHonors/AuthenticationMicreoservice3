using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using AuthenticationMicreoservice3.Model;
using AuthenticationMicreoservice3.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationMicreoservice3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _config;
        private IPentionerDetails _pentionerDetails;

        public AuthenticationController(IConfiguration configuration, IPentionerDetails pentionerDetails)
        {
            _config = configuration;
            _pentionerDetails = pentionerDetails;
        }
        // GET: api/<AuthenticationController>
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_pentionerDetails.GetPentioners());
        }

        // GET api/<AuthenticationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthenticationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthenticationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthenticationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
