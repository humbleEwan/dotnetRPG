﻿using Microsoft.AspNetCore.Mvc;
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
        public EncounterDTO rollEncounter() {
            return EncounterManager.Instance.rollNewEncounter();
        }

        [HttpPost]
        [Route("rotateEncounter")]
        public ActionResponseDTO rotateEncounter([FromBody] PlayerActionDTO playerAction) {
            try {
                return EncounterManager.Instance.rotateEncounter(playerAction);
            } catch(Exception e) { 
                Console.WriteLine(e);
                return new ActionResponseDTO("invalid", 10, false);
            }
        }
    }
}
