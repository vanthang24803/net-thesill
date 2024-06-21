using Api.TheSill.src.domain.dtos.product;
using Api.TheSill.src.domain.models;
using AutoMapper;

namespace Api.TheSill.src.common.mappers {
    public class ProductMapper : Profile {
        public ProductMapper() {
            CreateMap<ProductEntity, ProductResponse>();
            CreateMap<ProductEntity, ProductDetailResponse>();
        }
    }
}