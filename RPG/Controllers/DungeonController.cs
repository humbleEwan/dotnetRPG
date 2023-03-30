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
        [Route("rollEncounter")]
        public encounterDTO rollEncounter() {
            return EncounterManager.Instance.rollNewEncounter();
        }

        [HttpPost]
        [Route("rotateEncounter")]
        public actionResponseDTO rotateEncounter([FromBody] playerActionDTO playerAction) {
            try {
                return EncounterManager.Instance.rotateEncounter(playerAction);
            } catch(Exception e) { 
                Console.WriteLine(e);
                return new actionResponseDTO("invalid", 10, false);
            }
        }
    }
}
