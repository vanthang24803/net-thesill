using Api.TheSill.src.domain.dtos.category;
using Api.TheSill.src.domain.dtos.option;
using Api.TheSill.src.domain.dtos.photo;

namespace Api.TheSill.src.domain.dtos.product {
    public class ProductResponse {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Thumbnail { get; set; } = string.Empty;

        public bool Published { get; set; }

        public List<CategoryResponse> Categories = [];

        public DateTime CreateAt { get; set; }
    }
}