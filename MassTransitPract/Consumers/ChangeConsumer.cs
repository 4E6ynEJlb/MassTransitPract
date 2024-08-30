using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class ChangeConsumer : IConsumer<ChangeUserRequest>
    {
        private readonly WebApiClient _client;
        public ChangeConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<ChangeUserRequest> context)
        {
            await context.RespondAsync(await _client.AuthChange(context.Message));
        }
    }
}
