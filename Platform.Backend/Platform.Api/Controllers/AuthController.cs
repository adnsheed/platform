using Microsoft.AspNetCore.Mvc;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Auth;

namespace Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDto userLoginDto)
        {
            return Ok(await authService.Login(userLoginDto.Username, userLoginDto.Password));
        }
    }
}
