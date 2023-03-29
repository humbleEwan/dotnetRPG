using Microsoft.AspNetCore.Mvc;

namespace RPG.Controllers
{
    [ApiController]
    [Route("dungeon")]
    public class DungeonController : ControllerBase {

        [HttpGet]
        public IEnumerable<string> Get() {
            string[] a = { "spider" };
            return a;
        }
    }
}
