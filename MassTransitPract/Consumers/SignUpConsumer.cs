using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class SignUpConsumer : IConsumer<RegisterUserRequest>
    {
        private readonly WebApiClient _client;
        public SignUpConsumer(WebApiClient client) 
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<RegisterUserRequest> context)
        {
            await context.RespondAsync(await _client.AuthSignUp(context.Message));
        }
    }
}
