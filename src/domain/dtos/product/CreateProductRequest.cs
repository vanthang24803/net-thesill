using System.ComponentModel.DataAnnotations;
using Api.TheSill.src.domain.dtos.category;

namespace Api.TheSill.src.domain.dtos.product {
    public class CreateProductRequest {
        [Required(ErrorMessage = "Product name is required!")]
        [StringLength(255, ErrorMessage = "Name must be between 1 and 255 characters")]
        public string Name { get; set; } = string.Empty;
        public List<CategoryRequest> Categories { get; set; } = [];
    }
}