
using MassTransit;
using MassTransitPract.Consumers;

namespace MassTransitPract
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton(new WebApiClient());
            builder.Services.AddMassTransit(busRegistrationConfigurator =>
            {
                busRegistrationConfigurator.AddConsumer<AddPlayerConsumer>();
                busRegistrationConfigurator.AddConsumer<AddTeamConsumer>();
                busRegistrationConfigurator.AddConsumer<ChangeConsumer>();
                busRegistrationConfigurator.AddConsumer<DeleteImageConsumer>();
                busRegistrationConfigurator.AddConsumer<DeletePlayerConsumer>();
                busRegistrationConfigurator.AddConsumer<DeleteTeamConsumer>();
                busRegistrationConfigurator.AddConsumer<GetPlayerConsumer>();
                busRegistrationConfigurator.AddConsumer<GetPlayersConsumer>();
                busRegistrationConfigurator.AddConsumer<GetPositionsConsumer>();
                busRegistrationConfigurator.AddConsumer<GetTeamConsumer>();
                busRegistrationConfigurator.AddConsumer<GetTeamsConsumer>();
                busRegistrationConfigurator.AddConsumer<PingConsumer>();
                busRegistrationConfigurator.AddConsumer<SaveImageConsumer>();
                busRegistrationConfigurator.AddConsumer<SignInConsumer>();
                busRegistrationConfigurator.AddConsumer<SignUpConsumer>();
                busRegistrationConfigurator.AddConsumer<UpdatePlayerConsumer>();
                busRegistrationConfigurator.AddConsumer<UpdateTeamConsumer>();
                busRegistrationConfigurator.AddConsumer<VersionConsumer>();
                busRegistrationConfigurator.UsingRabbitMq((context, rabbitBusFactoryConfigurator) => 
                {
                    rabbitBusFactoryConfigurator.Host("rabbitmq", hostConfigurator =>
                    {
                        hostConfigurator.Username("guest");
                        hostConfigurator.Password("guest");
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("AddPlayerQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<AddPlayerConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("AddTeamQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<AddTeamConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("ChangeQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<ChangeConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("DeleteImageQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<DeleteImageConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("DeletePlayerQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<DeletePlayerConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("DeleteTeamQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<DeleteTeamConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("GetPlayerQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<GetPlayerConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("GetPlayersQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<GetPlayersConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("GetPositionsQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<GetPositionsConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("GetTeamQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<GetTeamConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("GetTeamsQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<GetTeamsConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("PingQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<PingConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("SaveImageQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<SaveImageConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("SignInQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<SignInConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("SignUpQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<SignUpConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("UpdatePlayerQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<UpdatePlayerConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("UpdateTeamQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<UpdateTeamConsumer>(context);
                    });
                    rabbitBusFactoryConfigurator.ReceiveEndpoint("VersionQueue", endpoint =>
                    {
                        endpoint.ConfigureConsumer<VersionConsumer>(context);
                    });
                    //rabbitBusFactoryConfigurator.ClearSerialization();
                    //rabbitBusFactoryConfigurator.UseRawJsonSerializer();
                    //rabbitBusFactoryConfigurator.UseRawJsonDeserializer();
                    rabbitBusFactoryConfigurator.ConfigureEndpoints(context);
                });
            });
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
