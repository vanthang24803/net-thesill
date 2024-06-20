using System.ComponentModel.DataAnnotations;

namespace Api.TheSill.src.domain.dtos.category {
    public class CategoryRequest {
        [Required(ErrorMessage = "Category name is Required!")]
        public string Name { get; set; } = string.Empty;
    }
}