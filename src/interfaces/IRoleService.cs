using Api.TheSill.src.common.helpers;
using Api.TheSill.src.domain.dtos.role;
using Api.TheSill.src.domain.enums;
using Api.TheSill.src.domain.models;

namespace Api.TheSill.src.repositories
{
    public interface IRoleService
    {
        Task<Response<List<RoleResponse>>> SeedRole();

        Task<Response<List<RoleResponse>>> FindAll();

        Task<RoleEntity> FindRoleByName(Role name);

        bool ExistByName(Role name);
    }
}