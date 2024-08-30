using MassTransit;
using MassTransitPract.Models;

namespace MassTransitPract.Consumers
{
    public class DeleteTeamConsumer : IConsumer<DeleteTeamRequest>
    {
        private readonly WebApiClient _client;
        public DeleteTeamConsumer(WebApiClient client)
        {
            _client = client;
        }
        public async Task Consume(ConsumeContext<DeleteTeamRequest> context)
        {
            await context.RespondAsync(await _client.TeamDelete(context.Message.Id));
        }
    }
}
