using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using VehicleManager.Application.Services.AutoMapper;
using VehicleManager.Application.Services.Cryptography;
using VehicleManager.Application.Usecases.User.Register;

namespace VehicleManager.Application;

public static class DepedencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddMapper(services);
        AddUseCases(services);
        AddEncrypter(services);
    }

    private static void AddMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }, NullLoggerFactory.Instance).CreateMapper());
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }

    private static void AddEncrypter(IServiceCollection services)
    {
        services.AddScoped(option => new PasswordEncrypter());
    }
}