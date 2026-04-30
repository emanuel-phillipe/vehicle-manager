using VehicleManager.Communication.Requests;
using VehicleManager.Communication.Responses;

namespace VehicleManager.Application.Usecases.User.Register;

public interface IRegisterUserUseCase
{
    public Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
}