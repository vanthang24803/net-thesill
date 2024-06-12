using Api.TheSill.src.common.helpers;
using Api.TheSill.src.domain.dtos.auth;
using Api.TheSill.src.domain.dtos.token;

namespace Api.TheSill.src.interfaces {
    public interface IAuthService {
        Task<Response<TokenResponse>> Login(SignUpRequest login);

        Task<Response<AuthResponse>> Register(SignInRequest register);
    }
}