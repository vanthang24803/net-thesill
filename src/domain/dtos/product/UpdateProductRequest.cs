using System.ComponentModel.DataAnnotations;

namespace Api.TheSill.src.domain.dtos.product {
    public class UpdateProductRequest {
        [Required(ErrorMessage = "Product name is required!")]
        [StringLength(255, ErrorMessage = "Name must be between 1 and 255 characters")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string? Guide { get; set;}

        public bool Published { get; set; }
    }
}