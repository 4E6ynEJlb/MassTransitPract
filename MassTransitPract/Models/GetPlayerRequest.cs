namespace MassTransitPract.Models
{
    public class GetPlayerRequest
    {
        public GetPlayerRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
