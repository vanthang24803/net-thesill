using Api.TheSill.src.repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.TheSill.src.controllers {
    [ApiController]
    [Route("api/auth/role")]
    public class RoleController : ControllerBase {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService) {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("seeds")]
        public async Task<IActionResult> Seeds() {
            var result = await _roleService.SeedRole();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = await _roleService.FindAll();
            return Ok(result);
        }
    }
}