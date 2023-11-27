namespace Quadro.Product.Infrastructure;

public static class Extensions
{

    public static IServiceCollection AddProductInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration is null)
            throw new ArgumentNullException(nameof(configuration));

        //AWS
        services.AddDefaultAWSOptions(configuration.GetAWSOptions());
        services.AddAWSService<IAmazonDynamoDB>();



        //DbContext
        services.AddScoped(typeof(ProductDbContext));

        //Repository
        services.AddTransient<IProductRepository, ProductRepository>();




        return services;
    }
}