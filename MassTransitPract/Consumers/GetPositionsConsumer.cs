using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class GetPositionsConsumer : IConsumer<GetPositionsRequest>
    {
        private readonly WebApiClient _client;
        public GetPositionsConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<GetPositionsRequest> context)
        {
            await context.RespondAsync(await _client.PlayerGetPositions());
        }
    }
}
