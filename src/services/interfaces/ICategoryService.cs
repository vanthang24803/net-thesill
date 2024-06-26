using Api.TheSill.src.common.helpers;
using Api.TheSill.src.domain.dtos.category;

namespace Api.TheSill.src.interfaces {
    public interface ICategoryService {
        Task<Response<List<CategoryResponse>>> Seeds();

        Task<Response<List<CategoryResponse>>> FindAll();

        Task<Response<CategoryResponse>> Create(CategoryRequest request);

        Task<Response<CategoryResponse>> Update(Guid id, CategoryRequest request);

        Task<Response<CategoryResponse>> GetOne(Guid id);

        Task<Response<string>> Delete(Guid id);

    }
}