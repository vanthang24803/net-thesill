using Api.TheSill.src.domain.dtos.auth;
using Api.TheSill.src.domain.models;
using AutoMapper;

namespace Api.TheSill.src.common.mappers {
    public class AuthMapper : Profile {
        public AuthMapper() {
            CreateMap<UserEntity, AuthResponse>(MemberList.Source);
        }
    }
}