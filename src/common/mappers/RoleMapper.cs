using Api.TheSill.src.domain.dtos.role;
using Api.TheSill.src.domain.models;
using AutoMapper;

namespace Api.TheSill.src.common.message {
    public class RoleMapper : Profile {
        public RoleMapper() {
            CreateMap<RoleEntity, RoleResponse>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                    .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt));
        }
    }
}