using Api.TheSill.src.repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.TheSill.src.controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public AuthController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("test")]
        public async Task<IActionResult> GetHelloWorld()
        {
            var result = await _roleService.Save();
            return Ok(result);
        }
    }
}