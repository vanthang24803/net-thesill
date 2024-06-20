using Api.TheSill.src.domain.models;

namespace Api.TheSill.src.interfaces {
    public interface IProductService {
        ProductEntity FindProductById(Guid id);

        bool ExistProductById(Guid id);
    }
}