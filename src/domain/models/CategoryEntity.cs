using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.TheSill.src.domain.models {
    [Table(name: "Categories")]
    public class CategoryEntity {
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(name: "category_name")]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        public List<ProductEntity> Products { get; set; } = [];

        [Column(name: "create_at")]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}