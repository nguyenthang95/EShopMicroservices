using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ordering.Application;

public static class DependencyInjection
{
public static IServiceCollection AddApplicationServices(this IServiceCollection service)
    {
        // Add services to the container
        service.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });

        return service;
    }
}
