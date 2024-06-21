using Api.TheSill.src.common.helpers;
using Api.TheSill.src.domain.dtos.product;

namespace Api.TheSill.src.interfaces {
    public interface IProductService {
        Task<Response<ProductResponse>> Save(IFormFile thumbnail, CreateProductRequest request);

        Task<Response<List<ProductResponse>>> FindAll();

        Task<Response<ProductDetailResponse>> GetById(Guid id);

        Task<Response<ProductDetailResponse>> Update(Guid id, UpdateProductRequest updateProductRequest);
        Task<Response<string>> Delete(Guid id);
    }
}