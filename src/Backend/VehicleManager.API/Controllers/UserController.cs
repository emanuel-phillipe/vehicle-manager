using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Register(RequestRegisterUserJson request)
        {
            return Created();
        }
    }
}
