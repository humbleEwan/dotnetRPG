using RPG.DTOs;
using RPG.Types;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace RPG.Utils
{
    public class EncounterManager {
        private static EncounterManager _instance = null;

        private EncounterManager() { }

        public static EncounterManager Instance { 
            get {
                if(_instance == null) {
                    _instance = new EncounterManager();
                }
                return _instance;
            } 
        }

        public EncounterDTO rollNewEncounter() {
            using (SHA256 sha256Hash = SHA256.Create()) {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(_ID.ToString() + "secureSalt")); //needs some form of 'dotenv'
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < bytes.Length; ++i) {
                    sb.Append(bytes[i].ToString("x2"));
                }
                ++_ID;
                DungeonEncounter de = generateEncounter();
                _encounters.Add(sb.ToString(), de);

                //for debug purposes
                for (int i = 0; i < _encounters.Count; ++i) {
                    Console.WriteLine(_encounters.ElementAt(i));
                }
                Console.WriteLine("----------------------------------------------------------------------------------"); //haha, I left a funny

                return new EncounterDTO(sb.ToString(), de.enemyName, de.HP);
            }
        }

        public ActionResponseDTO rotateEncounter(PlayerActionDTO playerAction) {
            if (!validActions.Contains(playerAction.actionUsed)) {
                throw new Exception("Invalid Action!");
            } else if(_encounters.ContainsKey(playerAction.encounterHash)) {
                DungeonEncounter processedEncounter = _encounters.GetValueOrDefault(playerAction.encounterHash);
                if (processedEncounter != null) {
                    switch(playerAction.actionUsed) {
                        case "basicAttack":
                            processedEncounter.HP -= 3;
                            if (processedEncounter.HP <= 0) {
                                _encounters.Remove(playerAction.encounterHash);
                                return new ActionResponseDTO(playerAction.encounterHash, 0, true);
                            } else {
                                return new ActionResponseDTO(playerAction.encounterHash, processedEncounter.HP, false);
                            }
                        case "guard":
                            return new ActionResponseDTO(playerAction.encounterHash, processedEncounter.HP, false);
                        default:
                            throw new Exception("An interesting error");
                    }
                } else {
                    throw new Exception("Internal error occured! Valid hash, but no encounter pair!");
                }
            } else {
                throw new Exception("Invalid encounter hash!");
            }
        }

        private int _ID = 0;
        private Dictionary<string, DungeonEncounter> _encounters = new Dictionary<string, DungeonEncounter>();

        private string[] validActions = { "basicAttack", "guard" };

        private DungeonEncounter generateEncounter() {
            Random random = new Random();
            int rand = random.Next(0, 3);
            Console.WriteLine(rand);
            switch(rand) {
                case 0:
                    return new DungeonEncounter("Spider", 10);
                case 1:
                    return new DungeonEncounter("Skeleton", 15);
                case 2:
                    return new DungeonEncounter("Zombie", 20);
                default:
                    return new DungeonEncounter("__DEFAULT__", 100000);
            }
        }
    }
}
