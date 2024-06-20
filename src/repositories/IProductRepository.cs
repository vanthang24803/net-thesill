using Api.TheSill.src.domain.models;

namespace Api.TheSill.src.repositories {
    public interface IProductRepository {
        ProductEntity FindProductById(Guid id);

        bool ExistProductById(Guid id);
    }
}