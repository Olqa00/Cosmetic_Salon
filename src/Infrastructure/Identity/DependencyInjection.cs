namespace CosmeticSalon.Infrastructure.Identity;

using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Infrastructure.Identity.Interfaces;
using CosmeticSalon.Infrastructure.Identity.Models;
using CosmeticSalon.Infrastructure.Identity.Services;
using CosmeticSalon.Infrastructure.Identity.Settings;
using Microsoft.Extensions.Configuration;

public static class DependencyInjection
{
    private const string OPTIONS_SECTION_NAME = "AccountSettings";

    public static IServiceCollection AddUserIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(OPTIONS_SECTION_NAME);
        services.Configure<UserAccountSettings>(section);

        services.Configure<IdentityOptions>(options =>
        {
            var accountConfiguration = configuration.GetSection(OPTIONS_SECTION_NAME).Get<UserAccountSettings>();
            options.Password.RequireDigit = accountConfiguration.PasswordRequireDigit;
            options.Password.RequireLowercase = accountConfiguration.PasswordRequireLowercase;
            options.Password.RequireNonAlphanumeric = accountConfiguration.PasswordRequireNonAlphanumeric;
            options.Password.RequireUppercase = accountConfiguration.PasswordRequireUppercase;
            options.Password.RequiredLength = accountConfiguration.PasswordRequiredLength;
            options.User.AllowedUserNameCharacters = accountConfiguration.AllowedUserNameCharacters;
            options.User.RequireUniqueEmail = accountConfiguration.RequireUniqueEmail;
        });

        services.AddIdentity<UserDbModel, RoleDbModel>()
            .AddEntityFrameworkStores<IdentityUserContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserMappingService, UserMappingService>();

        return services;
    }
}
