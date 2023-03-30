namespace RPG.DTOs
{
    public class ActionResponseDTO {
        public ActionResponseDTO(string encounterHash, int remainingHp, bool finished = false) {
            this.encounterHash = encounterHash;
            this.remainingHp = remainingHp;
            this.finished = finished;
        }
        public string encounterHash { get; set; }
        public int remainingHp { get; set; }
        public bool finished { get; set; }
    }
}
