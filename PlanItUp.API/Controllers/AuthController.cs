using Microsoft.AspNetCore.Mvc;
using PlanItUp.Common.CustomRequest.AuthRequest;
using PlanItUp.Services.Interfaces;

namespace PlanItUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // registrarse como usuario - rol=(user)

        [HttpPost("signup")]

        public async Task<IActionResult> SignUp([FromBody] SignUpRequest createClientRequest)
        {

            await _authService.SignUp(createClientRequest);
            return Ok("Succes");

        }
        [HttpPost("signin")]

        public async Task<IActionResult> SignIn([FromBody] LoginRequest loginRequest)
        {

            var result = await _authService.SignIn(loginRequest);
            return Ok(result.client_id);

        }

    }
}
