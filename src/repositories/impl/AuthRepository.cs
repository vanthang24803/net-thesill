using Api.TheSill.src.common.exceptions;
using Api.TheSill.src.common.message;
using Api.TheSill.src.context;
using Api.TheSill.src.domain.models;
using Microsoft.EntityFrameworkCore;

namespace Api.TheSill.src.repositories.impl {
    public class AuthRepository : IAuthRepository {

        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context) {
            _context = context;
        }

        public bool ExistByEmail(string email) {
            return _context.Users.Any(x => x.Email == email);
        }

        public async Task<UserEntity> FindUserByEmail(string email) {
            return await _context.Users.Include(r => r.Roles).FirstOrDefaultAsync(n => n.Email == email) ?? throw new NotFoundException(ErrorMessage.USER_NOT_FOUND);
        }

        public async Task<UserEntity> FindUserById(Guid id) {
            return await _context.Users.Include(r => r.Roles).FirstOrDefaultAsync(n => n.Id == id) ?? throw new NotFoundException(ErrorMessage.USER_NOT_FOUND);
        }
    }
}