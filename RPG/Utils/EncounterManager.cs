using RPG.DTOs;
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

        public encounterDTO rollNewEncounter() {
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

                return new encounterDTO(sb.ToString(), de.enemyName, de.HP);
            }
        }

        private int _ID = 0;
        private Dictionary<string, DungeonEncounter> _encounters = new Dictionary<string, DungeonEncounter>();

        private DungeonEncounter[] possibleEncounters = { //should be in a Json somewhere
            new DungeonEncounter("Spider", 10),
            new DungeonEncounter("Skeelton", 15),
            new DungeonEncounter("Zombie", 20)
        };

        private DungeonEncounter generateEncounter() {
            Random random = new Random();
            int start2 = random.Next(0, possibleEncounters.Length);
            return possibleEncounters[start2];
        }
    }
}
