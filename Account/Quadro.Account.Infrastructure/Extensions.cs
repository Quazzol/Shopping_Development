namespace Quadro.Account.Infrastructure.Extensions;

public static class Extensions
{

    public static IServiceCollection AddAccountInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        if (configuration is null)
            throw new ArgumentNullException(nameof(configuration));

        //AWS
        services.AddDefaultAWSOptions(configuration.GetAWSOptions());
        services.AddAWSService<IAmazonDynamoDB>();

        //DbContext
        services.AddScoped(typeof(AccountDbContext));

        //Repository
        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }

}