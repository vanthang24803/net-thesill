using Api.TheSill.src.domain.models;

namespace Api.TheSill.src.repositories {
    public interface ICategoryRepository {
        bool ExistByName(string name);

        Task<CategoryEntity> FindByName(string name);

        Task<CategoryEntity> FindOne(Guid id);

    }
}