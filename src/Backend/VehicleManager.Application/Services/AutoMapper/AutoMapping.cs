using AutoMapper;
using VehicleManager.Communication.Requests;

namespace VehicleManager.Application.Services.AutoMapper;

public class AutoMapping:Profile
{
    public AutoMapping()
    {
        RequestToDomain();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisterUserJson, Domain.Entities.User>()
            .ForMember(user => user.Password, opt => opt.Ignore());
    }
}