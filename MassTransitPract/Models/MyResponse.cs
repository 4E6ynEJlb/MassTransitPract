namespace MassTransitPract.Models
{
    public class MyResponse<T>
    {
        public T? Result { get; set; }
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage {  get; set; }
    }
}
