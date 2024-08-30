using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class DeleteImageConsumer : IConsumer<DeleteImageRequest>
    {
        private readonly WebApiClient _client;
        public DeleteImageConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<DeleteImageRequest> context)
        {
            await context.RespondAsync(await _client.ImageDeleteImage(context.Message.Name));
        }
    }
}
