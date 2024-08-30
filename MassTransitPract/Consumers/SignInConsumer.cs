using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class SignInConsumer:IConsumer<LoginRequest>
    {
        private readonly WebApiClient _client;
        public SignInConsumer(WebApiClient client)
        {
            _client = client;
        }

        public async Task Consume(ConsumeContext<LoginRequest> context)
        {
            await context.RespondAsync(await _client.AuthSignIn(context.Message));
        }
    }
}
