namespace CosmeticSalon.Infrastructure;

using System.Reflection;
using CosmeticSalon.Application.Users.Interfaces;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Infrastructure.DAL;
using CosmeticSalon.Infrastructure.DAL.Services;
using CosmeticSalon.Infrastructure.Identity;
using CosmeticSalon.Infrastructure.Identity.Interfaces;
using CosmeticSalon.Infrastructure.Identity.Services;
using Microsoft.Extensions.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddSqlServer(configuration);
        services.AddUserIdentity(configuration);

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITreatmentRepository, TreatmentRepository>();
        services.AddScoped<IUserMappingService, UserMappingService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
