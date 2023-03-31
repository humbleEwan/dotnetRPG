using Microsoft.AspNetCore.Mvc;
using RPG.Interfaces;
using RPG.Types;
using RPG.Models;
using System.Net;
using RPG.Utils;

namespace RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase {
        
        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(201, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> registerUser([FromBody] User newUser) {
            HttpStatusCode status = await _userRepository.addUser(newUser);
            switch(status) {
                case HttpStatusCode.OK: return Ok(newUser.username);
                case HttpStatusCode.NotModified: return BadRequest("Username already taken!");
                case HttpStatusCode.NotAcceptable: return BadRequest("Username or password does not match the criteria!");
                default: return BadRequest("Something went wrong!");
            }
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(401, Type = typeof(string))]
        public async Task<IActionResult> login([FromBody] LoginRequest loginRequest) {
            var success = await _userRepository.authenticateUser(loginRequest.username, loginRequest.password);
            if(success) {
                Response.Cookies.Append("jwtToken", new JWTokenHandler(loginRequest.username).generateToken());
            }
            return success ? Ok(loginRequest.username) : Unauthorized("Invalid username or password!");
        }

        private readonly IUserRepository _userRepository;
    }
}
