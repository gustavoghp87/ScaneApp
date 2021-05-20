using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WS_ScaneApp.Models.ProjectRequests;
using WS_ScaneApp.Models.ProjectResponses;
using WS_ScaneApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WS_ScaneApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/<UserController>
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] AuthRequest model)
        {
            ProjectResponse response = new();
            var userResponse = _userService.Auth(model);
            if (userResponse == null) {
                response.Success = 0;
                response.ErrorMessage = "User or Password wrong";
                return BadRequest(response);
            }
            response.Success = 1;
            response.Data = userResponse;
            return Ok(response);
        }



        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
