using Microsoft.AspNetCore.Mvc;
using VehicleManager.Application.Usecases.User.Register;
using VehicleManager.Communication.Requests;
using VehicleManager.Communication.Responses;

namespace VehicleManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromServices] IRegisterUserUseCase useCase, [FromBody] RequestRegisterUserJson request)
        {
            var result = await useCase.Execute(request);
            
            return Created(string.Empty, result);
        }
    }
}
