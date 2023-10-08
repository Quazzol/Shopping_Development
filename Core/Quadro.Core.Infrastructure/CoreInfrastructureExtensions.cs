namespace Quadro.Core.Infrastructure;

public static class CoreInfrastructureExtensions
{

    public static IServiceCollection AddCoreInfrastructure(this IServiceCollection services)
    {
        // EventBus
        services.TryAddSingleton<IEventDispatcher, EventDispatcher>();

            // CQRS
        services.AddScoped<ICommandBus, CommandBus>();
        services.AddScoped<IQueryBus, QueryBus>();


        return services;
    }

}