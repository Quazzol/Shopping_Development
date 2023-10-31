using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quadro.Core.Infrastructure.Email;
using Quadro.Core.Infrastructure.Encryption;

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

    public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration is null)
            throw new ArgumentNullException(nameof(configuration));

        services.AddSingleton(configuration.GetSection("EmailSettings").Get<EmailSettings>()!);
        services.AddAWSService<IAmazonSimpleEmailService>();
        services.AddTransient<IEmailService, EmailService>();

        services.AddSingleton<IEncryptionService, AesEncryptionService>();

        return services;
    }



}