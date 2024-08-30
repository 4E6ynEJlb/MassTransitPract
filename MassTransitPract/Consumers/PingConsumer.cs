using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class PingConsumer : IConsumer<PingRequest>
    {
        private readonly WebApiClient _client;
        public PingConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<PingRequest> context)
        {
            await context.RespondAsync(await _client.EchoPing());
        }
    }
}
