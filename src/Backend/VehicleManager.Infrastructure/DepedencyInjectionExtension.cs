using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehicleManager.Domain.Repositories.User;
using VehicleManager.Infrastructure.DataAccess;
using VehicleManager.Infrastructure.DataAccess.Repositories;

namespace VehicleManager.Infrastructure;

public static class DepedencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddDbContext_SqlServer(services);
        AddRepositories(services);
    }

    private static void AddDbContext_SqlServer(IServiceCollection services)
    {

        var connectionString = "Data Source=JOHNSONSERVER;Initial Catalog=vehicle-manager;User ID=sa;Password=505617;Trusted_Connection=True;TrustServerCertificate=True;";

        services.AddDbContext<VehicleManagerDbContext>(dbOptions =>
        {
            dbOptions.UseSqlServer(connectionString);
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
    }
}