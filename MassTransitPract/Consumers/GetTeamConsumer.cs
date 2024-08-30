using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class GetTeamConsumer : IConsumer<GetTeamRequest>
    {
        private readonly WebApiClient _client;
        public GetTeamConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<GetTeamRequest> context)
        {
            await context.RespondAsync(await _client.TeamGet(context.Message.Id));
        }
    }
}
