using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class UpdatePlayerConsumer : IConsumer<PlayerDto>
    {
        private readonly WebApiClient _client;
        public UpdatePlayerConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<PlayerDto> context)
        {
            await context.RespondAsync(await _client.PlayerUpdate(context.Message));
        }
    }
}
