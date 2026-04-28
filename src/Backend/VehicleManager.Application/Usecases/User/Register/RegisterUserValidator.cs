using FluentValidation;
using VehicleManager.Communication.Requests;
using VehicleManager.Exceptions;

namespace VehicleManager.Application.Usecases.User.Register;


public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson> 
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.FullName).NotNull().NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(user => user.Cpf.Length).NotNull().Equal(11).WithMessage("Cpf should be 11 digits");
        RuleFor(user => user.Email).EmailAddress().WithMessage("Email is required");
        RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(8).WithMessage("Password should be greater than or equal to 8 digits");
        RuleFor(user => user.Phone.Length).Equal(14).WithMessage("Phone number should be equal to 14 digits");
        RuleFor(user => user.Role).NotEmpty().WithMessage("Role is required");
        RuleFor(user => user.CnhCategories).NotEmpty().WithMessage("CNH categories is required");
        RuleFor(user => user.CnhDueDate).NotEmpty().WithMessage("CNH due date is required");
        RuleFor(user => user.CnhNum.Length).Equal(9).WithMessage("CNH number should be 9 digits");
    } }