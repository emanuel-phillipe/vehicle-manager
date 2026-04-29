using VehicleManager.Communication.Requests;
using VehicleManager.Communication.Responses;

namespace VehicleManager.Application.Usecases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
    {
        // Validar body da request
        Validate(request);
        
        // Após colocar o AutoMapper - GIT REFACTOR

        var user = new Domain.Entities.User
        {
            FullName = request.FullName,
            Email = request.Email,
            Password = request.Password,
            Cpf = request.Cpf,
            Role = request.Role,
            CnhNum = request.CnhNum,
            CnhDueDate = request.CnhDueDate,
            CnhCategories = request.CnhCategories,
        };
        
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