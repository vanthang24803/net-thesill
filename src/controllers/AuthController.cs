using Api.TheSill.src.common.validations;
using Api.TheSill.src.domain.dtos.auth;
using Api.TheSill.src.domain.dtos.token;
using Api.TheSill.src.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.TheSill.src.controllers {
    [ApiController]
    [Route("api/auth")]
    [ValidateModelState]
    public class AuthController : ControllerBase {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] SignInRequest request) {
            return Ok(await _authService.Register(request));
        }

        [HttpPost]
        [Route("refresh")]

        public async Task<IActionResult> Refresh(
            [FromBody] RefreshTokenRequest request
        ) {
            return Ok(await _authService.RefreshToken(request));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] SignUpRequest request) {
            return Ok(await _authService.Login(request));
        }
    }
}
