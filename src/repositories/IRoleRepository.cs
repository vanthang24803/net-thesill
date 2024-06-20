using Api.TheSill.src.domain.enums;
using Api.TheSill.src.domain.models;

namespace Api.TheSill.src.repositories {
    public interface IRoleRepository {
        bool ExistByName(Role name);

         Task<RoleEntity> FindRoleByName(Role name);
    }
}