namespace RPG.DTOs
{
    public class actionResponseDTO {
        public actionResponseDTO(string encounterHash, int remainingHp, bool finished = false) {
            this.encounterHash = encounterHash;
            this.remainingHp = remainingHp;
            this.finished = finished;
        }
        public string encounterHash { get; set; }
        public int remainingHp { get; set; }
        public bool finished { get; set; }
    }
}
