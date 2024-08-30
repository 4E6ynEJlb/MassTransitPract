namespace MassTransitPract.Models
{
    public class PlayerDtoPageResult
    {
        public PlayerDto[]? data {  get; set; }
        public int count { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }
}
