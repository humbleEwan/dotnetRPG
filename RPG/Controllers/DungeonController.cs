using Microsoft.AspNetCore.Mvc;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DungeonController : ControllerBase {

        DungeonEncounter[] possibleEncounters = {
            new DungeonEncounter("Spider", 10),
            new DungeonEncounter("Skeelton", 15),
            new DungeonEncounter("Zombie", 20)
        };

        [HttpGet]
        public IEnumerable<string> Get() {
            string[] a = { "spider" };
            return a;
        }

        [HttpGet]
        [Route("roll")]
        public DungeonEncounter rollEncounter() {
            Random random = new Random();
            int start2 = random.Next(0, possibleEncounters.Length);
            return possibleEncounters[start2];
        }

        [HttpPost]
        [Route("rotate")]
        public ActionResponse rotate() {
            return new ActionResponse();
        }
    }
}
