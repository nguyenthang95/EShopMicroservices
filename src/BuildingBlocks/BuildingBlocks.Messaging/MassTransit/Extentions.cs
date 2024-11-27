using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Messaging.MassTransit;

public static class Extentions
{
    public static IServiceCollection AddMessageBroker(
        this IServiceCollection services,
        IConfiguration configuration,
        Assembly? assembly = null
        )
    {
        // Implement RabbitMQ MassTransit configuration
        var host = configuration["MessageBroker:Host"];
        var userName = configuration["MessageBroker:UserName"];
        var password = configuration["MessageBroker:Password"];

        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            if (assembly != null)
                config.AddConsumers(assembly);

            config.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(host!), host =>
                {
                    host.Username(userName!);
                    host.Password(password!);
                });
                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
