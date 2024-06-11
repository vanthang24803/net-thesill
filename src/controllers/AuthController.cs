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

        [HttpGet("seeds")]
        public async Task<IActionResult> Seeds()
        {
            var result = await _roleService.SeedRole();
            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roleService.FindAll();
            return Ok(result);
        }
    }
}
