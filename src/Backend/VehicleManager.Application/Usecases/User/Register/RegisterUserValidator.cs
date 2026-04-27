using FluentValidation;
using VehicleManager.Communication.Requests;

namespace VehicleManager.Application.Usecases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson> 
{
    public  RegisterUserValidator()
    {
        RuleFor(user => user.FullName).NotEmpty();
        RuleFor(user => user.Cpf.Length).Equal(11);
        RuleFor(user => user.Email).EmailAddress();
        RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(8);
        RuleFor(user => user.Phone.Length).Equal(14);
        RuleFor(user => user.Role).NotEmpty();
        RuleFor(user => user.CnhCategories).NotEmpty();
        RuleFor(user => user.CnhDueDate).NotEmpty();
        RuleFor(user => user.CnhNum.Length).Equal(9);
    }
}