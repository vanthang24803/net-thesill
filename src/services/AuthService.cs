using System.Net;
using Api.TheSill.src.common.exceptions;
using Api.TheSill.src.common.helpers;
using Api.TheSill.src.common.message;
using Api.TheSill.src.context;
using Api.TheSill.src.domain.dtos.auth;
using Api.TheSill.src.domain.dtos.token;
using Api.TheSill.src.domain.models;
using Api.TheSill.src.interfaces;
using Api.TheSill.src.repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.TheSill.src.services {
    public class AuthService : IAuthService {

        private readonly ApplicationDbContext _context;

        private readonly IRoleService _roleService;

        private readonly TokenUtils _tokenUtils;

        private readonly IMapper _mapper;


        public AuthService(ApplicationDbContext context, IRoleService roleService, TokenUtils tokenUtils, IMapper mapper) {
            _context = context;
            _roleService = roleService;
            _tokenUtils = tokenUtils;
            _mapper = mapper;

        }

        public async Task<Response<TokenResponse>> Login(SignUpRequest login) {

            UserEntity user = await FindUserByEmail(login.Email);

            if (!BCrypt.Net.BCrypt.EnhancedVerify(login.Password, user.Password)) {
                throw new UnauthorizedException();
            }

            string refreshToken = _tokenUtils.GenerateRefreshToken(user);
            string accessToken = _tokenUtils.GenerateAccessToken(user);


            user.RefreshToken = refreshToken;

            await _context.SaveChangesAsync();

            var result = new TokenResponse() {
                RefreshToken = refreshToken,
                AccessToken = accessToken,
            };

            return new Response<TokenResponse> { Status = HttpStatusCode.OK, Result = result };
        }

        public async Task<Response<AuthResponse>> Register(SignInRequest register) {

            if (ExistByEmail(register.Email)) {
                throw new BadRequestException(ErrorMessage.EMAIL_TAKEN);
            }

            var customerRole = await _roleService.FindRoleByName(domain.enums.Role.CUSTOMER);

            UserEntity newUser = new();
            newUser.Roles.Add(customerRole);

            newUser = _mapper.Map<SignInRequest, UserEntity>(register);

            customerRole.Users.Add(newUser);
            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<AuthResponse>(newUser);

            return new Response<AuthResponse> { Status = HttpStatusCode.Created, Result = response };

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

        public async Task<Response<TokenResponse>> RefreshToken(RefreshTokenRequest request) {
            var payload = _tokenUtils.VerifyRefreshToken(request.Token);

            var user = await FindUserById(payload.Id);

            var result = new TokenResponse();

            string accessToken = _tokenUtils.GenerateAccessToken(user);

            result.AccessToken = accessToken;

            if (payload.Expires < DateTime.Now) {
                string refreshToken = _tokenUtils.GenerateRefreshToken(user);

                result.RefreshToken = refreshToken;

                return new Response<TokenResponse> { Status = HttpStatusCode.OK, Result = result };

            }

            result.RefreshToken = user.RefreshToken;

            return new Response<TokenResponse> { Status = HttpStatusCode.OK, Result = result };
        }
    }
}