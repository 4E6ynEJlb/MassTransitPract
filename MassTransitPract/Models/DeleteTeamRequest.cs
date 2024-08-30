namespace MassTransitPract.Models
{
    public class DeleteTeamRequest
    {
        public DeleteTeamRequest(int id) 
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
