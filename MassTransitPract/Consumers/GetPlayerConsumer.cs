using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class GetPlayerConsumer:IConsumer<GetPlayerRequest>
    {
        private readonly WebApiClient _client;
        public GetPlayerConsumer(WebApiClient client)
        {
            _client = client;
        }

        public async Task Consume(ConsumeContext<GetPlayerRequest> context)
        {
            await context.RespondAsync(await _client.PlayerGet(context.Message.Id));
        }
    }
}
