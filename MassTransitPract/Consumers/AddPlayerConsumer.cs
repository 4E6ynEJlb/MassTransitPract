using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class AddPlayerConsumer : IConsumer<NewPlayerDto>
    {
        private readonly WebApiClient _client;
        public AddPlayerConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<NewPlayerDto> context)
        {
            await context.RespondAsync(await _client.PlayerAdd(context.Message));
        }
    }
}
