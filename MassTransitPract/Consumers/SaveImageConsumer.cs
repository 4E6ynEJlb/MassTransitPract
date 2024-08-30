using MassTransit;
using Refit;

namespace MassTransitPract.Consumers
{
    public class SaveImageConsumer : IConsumer<ByteArrayPart>
    {
        private readonly WebApiClient _client;
        public SaveImageConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<ByteArrayPart> context)
        {
            await context.RespondAsync(await _client.ImageSaveImage(context.Message));
        }
    }
}
