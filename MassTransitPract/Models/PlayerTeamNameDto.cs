namespace MassTransitPract.Models
{
    public class PlayerTeamNameDto
    {
        public required string name { get; set; }
        public int number { get; set; }
        public required string position { get; set; }
        public int team { get; set; }
        public DateTime birthday { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public string? avatarUrl { get; set; }
        public int id { get; set; }
        public string? teamName { get; set; }
    }
}
