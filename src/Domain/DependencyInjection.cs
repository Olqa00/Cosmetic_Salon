namespace CosmeticSalon.Domain;

using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
