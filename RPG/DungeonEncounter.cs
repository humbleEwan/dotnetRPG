namespace RPG
{
    public class DungeonEncounter {
        public DungeonEncounter(string enemyName, int HP) {
            this.enemyName = enemyName;
            this.HP = HP;
        }
        public string enemyName { get; set; }
        public int HP { get; set; }
    }
}
