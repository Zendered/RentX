using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.User;
using RentX.Services.Authentication;

namespace RentX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService authService;

        public AuthController(IAuthenticationService authService)
        {
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<Guid>>> Register(UserRegisterDto request)
        {
            var user = new User { Email = request.Email };
            var res = await authService.Register(user, request.Password);

            return res.Success is true ? Ok(res) : BadRequest(res);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var res = await authService.Login(request.Email, request.Password);

            return res.Success is true ? Ok(res) : BadRequest(res);
        }
    }
}
