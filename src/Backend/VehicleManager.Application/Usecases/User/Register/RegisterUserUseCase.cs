using AutoMapper;
using VehicleManager.Application.Services.Cryptography;
using VehicleManager.Communication.Requests;
using VehicleManager.Communication.Responses;
using VehicleManager.Domain.Repositories.User;

namespace VehicleManager.Application.Usecases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    
    // Repositórios 
    private readonly IUserReadOnlyRepository  _readOnlyRepository;
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IMapper _mapper;
    private readonly PasswordEncrypter _passwordEncrypter;

    public RegisterUserUseCase(IUserReadOnlyRepository readOnlyRepository, 
        IUserWriteOnlyRepository writeOnlyRepository, IMapper mapper, PasswordEncrypter passwordEncrypter)
    {
        _readOnlyRepository = readOnlyRepository;
        _writeOnlyRepository = writeOnlyRepository;
        _mapper = mapper;
        _passwordEncrypter = passwordEncrypter;
    }
    
    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        // Validação do request
        Validate(request);

        // Mapping da entidade
        var user = _mapper.Map<Domain.Entities.User>(request);

        //Criptografia da senha do usuário
        user.Password = _passwordEncrypter.Encrypt(request.Password);
        
        await _writeOnlyRepository.Add(user);
        
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