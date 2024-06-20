
namespace Api.TheSill.src.domain.dtos.category {
    public class CategoryResponse {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DateTime CreateAt { get; set; }
    }
}