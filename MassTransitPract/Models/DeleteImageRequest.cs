namespace MassTransitPract.Models
{
    public class DeleteImageRequest
    {
        public DeleteImageRequest(string name) { Name = name; }
        public string Name {  get; set; }
    }
}
