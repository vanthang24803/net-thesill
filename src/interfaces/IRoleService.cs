using Api.TheSill.src.common.helpers;
using Api.TheSill.src.domain.dtos.role;


namespace Api.TheSill.src.repositories {
    public interface IRoleService {
        Task<Response<List<RoleResponse>>> SeedRole();

        Task<Response<List<RoleResponse>>> FindAll();
    }
}