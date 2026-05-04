using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleManager.Domain.Repositories;
using VehicleManager.Domain.Repositories.User;
using VehicleManager.Infrastructure.DataAccess;
using VehicleManager.Infrastructure.DataAccess.Repositories;

namespace VehicleManager.Infrastructure;

public static class DepedencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext_SqlServer(services, configuration);
        AddRepositories(services);
    }

    private static void AddDbContext_SqlServer(IServiceCollection services, IConfiguration configuration)
    {
        
        var connectionString = configuration.GetConnectionString("Connection");

        services.AddDbContext<VehicleManagerDbContext>(dbOptions =>
        {
            dbOptions.UseSqlServer(connectionString);
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
    }
}