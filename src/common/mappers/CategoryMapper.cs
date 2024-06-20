using Api.TheSill.src.domain.dtos.category;
using Api.TheSill.src.domain.models;
using AutoMapper;

namespace Api.TheSill.src.common.mappers {
    public class CategoryMapper : Profile {
        public CategoryMapper() {
            CreateMap<CategoryEntity, CategoryResponse>();
        }
    }
}