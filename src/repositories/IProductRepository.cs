using Api.TheSill.src.domain.models;

namespace Api.TheSill.src.repositories {
    public interface IProductRepository {
        Task<ProductEntity> FindProductById(Guid id);

        bool ExistProductById(Guid id);

        Task<List<ProductEntity>> GetAll();
    }
}