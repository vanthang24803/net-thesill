using Api.TheSill.src.common.helpers;
using Api.TheSill.src.domain.dtos.auth;
using Api.TheSill.src.domain.dtos.token;
using Api.TheSill.src.domain.models;

namespace Api.TheSill.src.interfaces {
    public interface IAuthService {
        Task<Response<TokenResponse>> Login(SignUpRequest login);

        Task<Response<AuthResponse>> Register(SignInRequest register);

        Task<Response<TokenResponse>> RefreshToken(RefreshTokenRequest login);

        bool ExistByEmail(string email);

        Task<UserEntity> FindUserByEmail(string email);

        Task<UserEntity> FindUserById(Guid id);
    }
}