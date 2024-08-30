using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class UpdateTeamConsumer : IConsumer<TeamDto>
    {
        private readonly WebApiClient _client;
        public UpdateTeamConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<TeamDto> context)
        {
            await context.RespondAsync(await _client.TeamUpdate(context.Message));
        }
    }
}
