namespace CosmeticSalon.Infrastructure.Security;

using CosmeticSalon.Application.Security;
using CosmeticSalon.Domain.Entities;

internal static class DependencyInjection
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>()
            .AddSingleton<IPasswordManager, PasswordManager>();

        return services;
    }
}
