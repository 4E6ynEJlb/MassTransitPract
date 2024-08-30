using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class AddTeamConsumer : IConsumer<NewTeamDto>
    {
        private readonly WebApiClient _client;
        public AddTeamConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<NewTeamDto> context)
        {
            await context.RespondAsync(await _client.TeamAdd(context.Message));
        }
    }
}
