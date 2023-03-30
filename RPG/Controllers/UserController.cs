using System.Net;
using Microsoft.AspNetCore.Mvc;
using RPG.Interfaces;
using RPG.Types;
using RPG.Models;

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
        public HttpStatusCode registerUser([FromBody] User newUser) {
            _userRepository.addUser(newUser);
            return HttpStatusCode.Created;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(401, Type = typeof(string))]
        public IActionResult login([FromBody] LoginRequest loginRequest) {
            Console.WriteLine("User login request for: " + loginRequest.username);
            if(_userRepository.authenticateUser(loginRequest.username, loginRequest.password)) {
                Console.WriteLine("Accepted!");
                return Ok(loginRequest.username);
            } else {
                Console.WriteLine("Rejected!");
                return Unauthorized("Invalid username or password!");
            }
        }

        private readonly IUserRepository _userRepository;
    }
}
