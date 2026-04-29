using Microsoft.Extensions.Logging.Abstractions;
using VehicleManager.Application.Services.AutoMapper;
using VehicleManager.Communication.Requests;
using VehicleManager.Communication.Responses;

namespace VehicleManager.Application.Usecases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
    {
        // Validar body da request
        Validate(request);

        var autoMapper = new AutoMapper.MapperConfiguration(options=>
        {
            options.AddProfile(new AutoMapping());
        }, NullLoggerFactory.Instance).CreateMapper();

        var user = autoMapper.Map<Domain.Entities.User>(request);
        
        return new ResponseRegisterUserJson()
        {
            FullName = request.FullName,
            Email = request.Email,
        };
    }

    public void Validate(RequestRegisterUserJson request)
    {
        var validator =  new RegisterUserValidator();

        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errorMsg = result.Errors.Select(e => e.ErrorMessage);
            throw new Exception();
        }
    }
}