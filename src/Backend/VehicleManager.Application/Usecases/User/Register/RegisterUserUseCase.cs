using VehicleManager.Communication.Requests;
using VehicleManager.Communication.Responses;

namespace VehicleManager.Application.Usecases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
    {
        
        Validate(request);
        
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