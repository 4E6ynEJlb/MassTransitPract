using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class VersionConsumer : IConsumer<VersionRequest>
    {
        private readonly WebApiClient _client;
        public VersionConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<VersionRequest> context)
        {
            await context.RespondAsync(await _client.EchoVersion());
        }
    }
}
