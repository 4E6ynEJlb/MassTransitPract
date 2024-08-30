using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class GetTeamsConsumer : IConsumer<GetTeamsArgs>
    {
        private readonly WebApiClient _client;
        public GetTeamsConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<GetTeamsArgs> context)
        {
            await context.RespondAsync(await _client.TeamGetTeams(context.Message));
        }
    }
}
