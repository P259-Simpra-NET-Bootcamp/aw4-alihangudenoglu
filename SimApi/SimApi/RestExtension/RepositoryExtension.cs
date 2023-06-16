using SimApi.Data.Repository;

namespace SimApi.Service.RestExtension;

public static class RepositoryExtension
{
    public static void AddRepositoryExtension(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository,ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
