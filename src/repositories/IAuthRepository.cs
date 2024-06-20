using Api.TheSill.src.domain.models;

namespace Api.TheSill.src.repositories {
    public interface IAuthRepository {
        bool ExistByEmail(string email);

        Task<UserEntity> FindUserByEmail(string email);

        Task<UserEntity> FindUserById(Guid id);
    }
}