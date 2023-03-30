using Microsoft.AspNetCore.Mvc;
using RPG.DTOs;
using RPG.Utils;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DungeonController : ControllerBase {

        [HttpGet]
        public IEnumerable<string> Get() {
            string[] a = { "spider" };
            return a;
        }

        [HttpGet]
        [Route("roll")]
        public encounterDTO rollEncounter() {
            return EncounterManager.Instance.rollNewEncounter();
        }

        [HttpPost]
        [Route("rotate")]
        public ActionResponse rotate() {
            return new ActionResponse();
        }
    }
}
