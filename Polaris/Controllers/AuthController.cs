using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Polaris.Dtos.User;
using Polaris.Services.AuthService;

namespace Polaris.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> RegisterAsync(UserRegisterDto request)
        {
            var response = await this._authService.RegisterAsync(
                new Models.User { Username = request.username }, request.password);

            return response.Success ? this.Ok(response) : this.BadRequest(response);
        }
    }
}
