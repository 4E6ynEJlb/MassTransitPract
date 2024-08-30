namespace MassTransitPract.Models
{
    public class GetTeamRequest
    {
        public GetTeamRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
