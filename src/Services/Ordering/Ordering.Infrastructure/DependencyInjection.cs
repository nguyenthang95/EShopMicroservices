using Microsoft.Extensions.Options;
using Ordering.Application.Data;
using Ordering.Infrastructure.Data.Interceptors;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices( this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        // Add services to the container
        services.AddDbContext<ApplicationDbContext>((sp, opts) =>
        {
            opts.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            opts.UseSqlServer(connectionString);
        });

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

       

        return services;
    }
}
