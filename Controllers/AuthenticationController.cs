using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using AuthenticationMicreoservice3.Model;
using AuthenticationMicreoservice3.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Text.Encodings;
using System.Security.Claims;
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
        [AllowAnonymous]
        public IActionResult Post([FromBody] Pentioner pentioner)
        {
            
            if (_pentionerDetails.GetPentioner(pentioner) != null)
            {
                var tockenString = GenerateJWTocken(pentioner);
                return Ok(new {tocken = tockenString});
            }
            return Unauthorized();
        }
        public string GenerateJWTocken(Pentioner pentioner)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, pentioner.Name)
            };
            var tocken = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: System.DateTime.Now.AddMinutes(120),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(tocken);
        }




        // PUT api/<AuthenticationController>/5
        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Success full Put unautherized");
        }

        // DELETE api/<AuthenticationController>/5
        [HttpDelete]
        [Authorize]
        public IActionResult Delete()
        {
            return Ok("Success full Delete Autherized");
        }
    }
}
