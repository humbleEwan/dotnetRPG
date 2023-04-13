using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RPG.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class CharacterController : ControllerBase {

        [HttpGet]
        [Route("load")]
        public string load() {

            //should return the players character or a message that forces the forntend to charactr creation

            return "undefined";
        }
    }
}
