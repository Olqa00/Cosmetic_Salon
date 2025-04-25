namespace CosmeticSalon.Infrastructure.DAL;

using CosmeticSalon.Infrastructure.Identity;
using Microsoft.Extensions.Configuration;

public static class DependencyInjection
{
    private const string OPTIONS_SECTION_NAME = "SqlServer";

    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(OPTIONS_SECTION_NAME);
        services.Configure<SqlServerOptions>(section);
        var options = configuration.GetOptions<SqlServerOptions>(OPTIONS_SECTION_NAME);

        services.AddDbContext<CosmeticSalonDbContext>(option => option.UseSqlServer(options.ConnectionString));
        services.AddDbContext<IdentityUserContext>(option => option.UseSqlServer(options.ConnectionString));

        return services;
    }

    private static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}
