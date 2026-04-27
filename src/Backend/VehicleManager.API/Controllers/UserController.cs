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
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status200OK)]
        public IActionResult Register(RequestRegisterUserJson request)
        {
            return Ok(new ResponseRegisterUserJson() {Email = request.Email, RegisterNum = 544987});
        }
    }
}
