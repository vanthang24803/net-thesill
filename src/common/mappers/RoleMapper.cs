using Api.TheSill.src.domain.dtos.role;
using Api.TheSill.src.domain.models;
using AutoMapper;

namespace Api.TheSill.src.common.message {
    public class RoleMapper : Profile {
        public RoleMapper() {
            CreateMap<RoleEntity, RoleResponse>();
        }
    }
}