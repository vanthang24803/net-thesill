using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.TheSill.src.domain.models {
    [Table(name: "Products")]
    public class ProductEntity {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        [Column(name: "product_name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(name: "product_thumbnail", TypeName = "TEXT")]
        public string Thumbnail { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Guide { get; set; }

        public bool Published { get; set; }

        public List<CategoryEntity> Categories { get; set; } = [];

        [Column(name: "create_at")]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        [Column(name: "update_at")]
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
    }
}