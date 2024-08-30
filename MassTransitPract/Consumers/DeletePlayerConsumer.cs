using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class DeletePlayerConsumer:IConsumer<DeletePlayerRequest>
    {
        private readonly WebApiClient _client;
        public DeletePlayerConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<DeletePlayerRequest> context)
        {
            await context.RespondAsync(await _client.PlayerDelete(context.Message.Id));
        }
    }
}
