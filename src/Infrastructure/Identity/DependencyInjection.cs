namespace CosmeticSalon.Infrastructure.Identity;

using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Infrastructure.Identity.Models;
using CosmeticSalon.Infrastructure.Identity.Settings;
using CosmeticSalon.Infrastructure.Services;
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

        services.AddIdentity<UserIdentityModel, RoleModel>()
            .AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
