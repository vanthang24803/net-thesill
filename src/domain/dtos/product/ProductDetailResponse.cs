using Api.TheSill.src.domain.dtos.category;
using Api.TheSill.src.domain.dtos.option;
using Api.TheSill.src.domain.dtos.photo;

namespace Api.TheSill.src.domain.dtos.product {
    public class ProductDetailResponse {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Thumbnail { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Guide { get; set; }

        public bool Published { get; set; }

        public List<PhotoResponse> Photos = [];

        public List<CategoryResponse> Categories = [];

        public List<OptionResponse> Options = [];

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}