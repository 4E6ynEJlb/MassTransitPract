using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class GetPlayersConsumer:IConsumer<GetPlayersArgs>
    {
        private readonly WebApiClient _client;
        public GetPlayersConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<GetPlayersArgs> context)
        {
            await context.RespondAsync(await _client.PlayerGetPlayers(context.Message));
        }
    }
}
