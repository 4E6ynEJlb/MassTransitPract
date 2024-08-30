namespace MassTransitPract.Models
{
    public class DeletePlayerRequest
    {
        public DeletePlayerRequest(int id) 
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
