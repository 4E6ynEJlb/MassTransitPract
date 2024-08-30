namespace MassTransitPract.Models
{
    public class NewTeamDto
    {
        public required string name { get; set; }
        public int foundationYear { get; set; }
        public string? division { get; set; }
        public string? conference { get; set; }
        public string? imageUrl { get; set; }
    }
}
