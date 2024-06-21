using Api.TheSill.src.common.helpers;
using Api.TheSill.src.domain.dtos.auth;

namespace Api.TheSill.src.interfaces
{
    public interface IProfileService
    {
        Task<Response<AuthResponse>> GetProfileAsync();
    }
}