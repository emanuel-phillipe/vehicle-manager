using FluentValidation;
using VehicleManager.Communication.Requests;
using VehicleManager.Exceptions;

namespace VehicleManager.Application.Usecases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson> 
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.FullName).NotNull().NotEmpty().WithMessage(ResourceMessagesException.NAME_ERROR);
        RuleFor(user => user.Cpf.Length).NotNull().NotEmpty().Equal(11).WithMessage(ResourceMessagesException.CPF_ERROR);
        RuleFor(user => user.Email).NotNull().NotEmpty().EmailAddress().WithMessage(ResourceMessagesException.EMAIL_ERROR);
        RuleFor(user => user.Password.Length).NotNull().NotEmpty().GreaterThanOrEqualTo(8).WithMessage(ResourceMessagesException.PASSWORD_ERROR);
        RuleFor(user => user.Phone.Length).NotNull().NotEmpty().Equal(14).WithMessage(ResourceMessagesException.PHONE_ERROR);
        RuleFor(user => user.Role).NotNull().NotEmpty().WithMessage(ResourceMessagesException.ROLE_ERROR);
        RuleFor(user => user.CnhCategories).NotNull().NotEmpty().WithMessage(ResourceMessagesException.CNH_CATEGORIES_ERROR);
        RuleFor(user => user.CnhDueDate).NotNull().NotEmpty().WithMessage(ResourceMessagesException.CNH_DUE_DATE_ERROR);
        RuleFor(user => user.CnhNum.Length).NotNull().NotEmpty().Equal(9).WithMessage(ResourceMessagesException.CNH_NUM_ERROR);
    } 
}