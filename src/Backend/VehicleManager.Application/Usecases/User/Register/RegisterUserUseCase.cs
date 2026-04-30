using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using VehicleManager.Application.Services.Cryptography;
using VehicleManager.Communication.Requests;
using VehicleManager.Communication.Responses;
using VehicleManager.Domain.Repositories;
using VehicleManager.Domain.Repositories.User;
using VehicleManager.Exceptions;
using VehicleManager.Exceptions.ExceptionsBase;

namespace VehicleManager.Application.Usecases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    
    // Repositórios 
    private readonly IUserReadOnlyRepository  _readOnlyRepository;
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncrypter _passwordEncrypter;

    public RegisterUserUseCase(IUserReadOnlyRepository readOnlyRepository, 
        IUserWriteOnlyRepository writeOnlyRepository, IMapper mapper, PasswordEncrypter passwordEncrypter, IUnityOfWork unityOfWork)
    {
        _readOnlyRepository = readOnlyRepository;
        _writeOnlyRepository = writeOnlyRepository;
        _mapper = mapper;
        _passwordEncrypter = passwordEncrypter;
        _unityOfWork = unityOfWork;
    }
    
    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        // Validação do request
        await Validate(request);

        // Mapping da entidade
        var user = _mapper.Map<Domain.Entities.User>(request);

        //Criptografia da senha do usuário
        user.Password = _passwordEncrypter.Encrypt(request.Password);
        
        // Geração da Matrícula (2 primeiras letras do nome + número único) (RegisterNum)
        user.RegisterNum = await GenerateUniqueRegisterNum(user.FullName);
        
        await _writeOnlyRepository.Add(user);
        await _unityOfWork.CommitAsync();
        
        return new ResponseRegisterUserJson()
        {
            FullName = user.FullName,
            Email = user.Password,
        };
    }

    private async Task<string> GenerateUniqueRegisterNum(string fullName)
    {
        string prefix = fullName[..2].ToUpper();
        int registerNum;
        bool alreadyExists;

        do
        {
            registerNum = Random.Shared.Next(100000, 999999);
            alreadyExists = await _readOnlyRepository.GetByRegisterNum(registerNum);
        } while (alreadyExists);
        
        return $"{prefix}{registerNum}";
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
        var validator =  new RegisterUserValidator();

        var result = validator.Validate(request);

        var existUser = await _readOnlyRepository.ExistByEmail(request.Email);
        if (existUser)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceMessagesException.EMAIL_ALREADY_EXISTS));
        }
        
        if (!result.IsValid)
        {
            var errorMsgs = result.Errors.Select(e => e.ErrorMessage);
            throw new ErrorValidationException(errorMsgs.ToList());
        }
    }
}