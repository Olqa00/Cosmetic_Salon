namespace CosmeticSalon.Infrastructure;

using CosmeticSalon.Infrastructure.DAL;
using CosmeticSalon.Infrastructure.Security;
using Microsoft.Extensions.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSecurity();
        services.AddSqlServer(configuration);

        return services;
    }
}
