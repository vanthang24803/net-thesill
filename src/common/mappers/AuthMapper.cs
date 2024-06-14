using Api.TheSill.src.domain.dtos.auth;
using Api.TheSill.src.domain.models;
using AutoMapper;

namespace Api.TheSill.src.common.mappers {
    public class AuthMapper : Profile {
        public AuthMapper() {
            CreateMap<UserEntity, AuthResponse>();
            CreateMap<SignInRequest, UserEntity>()
              .ForMember(dest => dest.Password, opt => opt.MapFrom(src => HashPassword(src.Password)));
        }

        private static string HashPassword(string password) {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 10);
        }
    }
}