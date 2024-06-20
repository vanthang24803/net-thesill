using Api.TheSill.src.common.exceptions;
using Api.TheSill.src.common.message;
using Api.TheSill.src.context;
using Api.TheSill.src.domain.enums;
using Api.TheSill.src.domain.models;
using Microsoft.EntityFrameworkCore;


namespace Api.TheSill.src.repositories.impl {
    public class RoleRepository : IRoleRepository {

        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context) {
            _context = context;
        }
        public bool ExistByName(Role role) {
            return _context.Roles.Any(n => n.Role == role);
        }

        public async Task<RoleEntity> FindRoleByName(Role name) {
            var role = await _context.Roles.FirstOrDefaultAsync(n => n.Role == name) ?? throw new NotFoundException(ErrorMessage.ROLE_NOT_FOUND);

            return role;
        }
    }
}