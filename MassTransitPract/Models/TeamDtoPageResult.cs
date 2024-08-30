namespace MassTransitPract.Models
{
    public class TeamDtoPageResult
    {
        public TeamDto[]? data { get; set; }
        public int count { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }
}
