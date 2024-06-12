using System.Net;
using Api.TheSill.src.common.helpers;
using Api.TheSill.src.context;
using Api.TheSill.src.domain.dtos.auth;
using Api.TheSill.src.domain.dtos.token;
using Api.TheSill.src.domain.models;
using Api.TheSill.src.interfaces;
using Api.TheSill.src.repositories;

namespace Api.TheSill.src.services {
    public class AuthService : IAuthService {

        private readonly ApplicationDbContext _context;

        private readonly IRoleService _roleService;

        private readonly TokenUtils _tokenUtils;


        public AuthService(ApplicationDbContext context, IRoleService roleService, TokenUtils tokenUtils) {
            _context = context;
            _roleService = roleService;
            _tokenUtils = tokenUtils;

        }

        public Task<Response<TokenResponse>> Login(SignUpRequest login) {

            var user = new UserEntity {
                Id = Guid.NewGuid(),
                FirstName = "May",
                LastName = "Nguyen",
                Email = "mail@example.com",
            };

            string refreshToken = _tokenUtils.GenerateRefreshToken(user);
            string accessToken = _tokenUtils.GenerateAccessToken(user);

            var result = new TokenResponse() {
                RefreshToken = refreshToken,
                AccessToken = accessToken,
            };

            return Task.FromResult(new Response<TokenResponse> { Status = HttpStatusCode.OK, Result = result });
        }

        public Task<Response<AuthResponse>> Register(SignInRequest register) {

            throw new NotImplementedException();

        }
    }
}