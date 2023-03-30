namespace RPG
{
    public class DungeonEncounter {
        public DungeonEncounter(string enemyName, int HP) {
            this.enemyName = enemyName;
            this.HP = HP;
            this.finished = false;
        }
        public string enemyName { get; set; }
        public int HP { get; set; }
        public bool finished { get; set; }
    }
}
