using Microsoft.AspNetCore.Mvc;
using PruebaPeriferia.Application.Interfaces;

namespace PruebaPeriferia.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string name) 
        {
            bool isLogin = await _authService.Login(name);

            if (isLogin) { return Ok(_authService.GenerateToken(name)); }

            return NotFound();
        }
    }
}
