using Microsoft.Extensions.Logging.Abstractions;
using VehicleManager.Application.Services.AutoMapper;
using VehicleManager.Application.Services.Cryptography;
using VehicleManager.Communication.Requests;
using VehicleManager.Communication.Responses;

namespace VehicleManager.Application.Usecases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
    {
        // OBS - INJEÇÃO DE DEPENDÊNCIAS NÃO INICIADA
        //Inicialização de classes (Encriptação e AutoMapper)
        var passwordCrypto = new PasswordEncrypter();
        var autoMapper = new AutoMapper.MapperConfiguration(options=>
        {
            options.AddProfile(new AutoMapping());
        }, NullLoggerFactory.Instance).CreateMapper();
        
        // Validação do request
        Validate(request);

        // Mapping da entidade
        var user = autoMapper.Map<Domain.Entities.User>(request);

        //Criptografia da senha do usuário
        user.Password = passwordCrypto.Encrypt(request.Password);
        
        return new ResponseRegisterUserJson()
        {
            FullName = user.FullName,
            Email = user.Password,
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