namespace RPG.DTOs
{
    public class EncounterDTO {
        public EncounterDTO(string hash, string enemyName, int HP) {
            this.hash = hash;
            this.enemyName = enemyName;
            this.HP = HP;
        }
        public string hash { get; set; }
        public string enemyName { get; set; }
        public int HP { get; set; }
    }
}
