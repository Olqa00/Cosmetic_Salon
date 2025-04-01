namespace CosmeticSalon.Infrastructure;

using System.Reflection;
using CosmeticSalon.Domain.Interfaces;
using CosmeticSalon.Infrastructure.DAL;
using CosmeticSalon.Infrastructure.Identity;
using CosmeticSalon.Infrastructure.Services;
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

        services.AddScoped<ITreatmentRepository, TreatmentRepository>();

        return services;
    }
}
