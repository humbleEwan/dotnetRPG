using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RPG.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class CharacterController : ControllerBase {

        [HttpGet]
        public string Get() {
            return "agyverzes";
        }
    }
}
