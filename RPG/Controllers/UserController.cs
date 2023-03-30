using Microsoft.AspNetCore.Mvc;
using RPG.Interfaces;
using RPG.Types;
using RPG.Models;
using System.Net;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController {
        
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
        public void login([FromBody] LoginRequest loginRequest) {

        }

        private readonly IUserRepository _userRepository;
    }
}
