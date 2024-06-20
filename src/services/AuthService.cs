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

namespace Api.TheSill.src.services {
    public class AuthService : IAuthService {

        private readonly ApplicationDbContext _context;

        private readonly IRoleRepository _roleRepository;

        private readonly IAuthRepository _authRepository;

        private readonly TokenUtils _tokenUtils;

        private readonly IMapper _mapper;

        public AuthService(ApplicationDbContext context, TokenUtils tokenUtils, IMapper mapper, IRoleRepository roleRepository, IAuthRepository authRepository) {
            _context = context;
            _tokenUtils = tokenUtils;
            _mapper = mapper;
            _roleRepository = roleRepository;
            _authRepository = authRepository;
        }

        public async Task<Response<TokenResponse>> Login(SignUpRequest login) {

            UserEntity user = await _authRepository.FindUserByEmail(login.Email);

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

            return new Response<TokenResponse>(status: HttpStatusCode.OK, result: result);
        }

        public async Task<Response<AuthResponse>> Register(SignInRequest register) {

            if (_authRepository.ExistByEmail(register.Email)) {
                throw new BadRequestException(ErrorMessage.EMAIL_TAKEN);
            }

            var customerRole = await _roleRepository.FindRoleByName(domain.enums.Role.CUSTOMER);

            UserEntity newUser = new();
            newUser.Roles.Add(customerRole);

            newUser = _mapper.Map<SignInRequest, UserEntity>(register);

            customerRole.Users.Add(newUser);
            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<AuthResponse>(newUser);

            return new Response<AuthResponse>(status: HttpStatusCode.Created, result: response);

        }

        public async Task<Response<TokenResponse>> RefreshToken(RefreshTokenRequest request) {
            var payload = _tokenUtils.VerifyRefreshToken(request.Token);

            var user = await _authRepository.FindUserById(payload.Id);

            var result = new TokenResponse();

            string accessToken = _tokenUtils.GenerateAccessToken(user);

            result.AccessToken = accessToken;

            if (payload.Expires < DateTime.Now) {
                string refreshToken = _tokenUtils.GenerateRefreshToken(user);

                result.RefreshToken = refreshToken;

                return new Response<TokenResponse>(status: HttpStatusCode.OK, result: result);

            }

            result.RefreshToken = user.RefreshToken;

            return new Response<TokenResponse>(status: HttpStatusCode.OK, result: result);
        }
    }
}