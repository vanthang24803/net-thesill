using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.TheSill.src.domain.models {
    [Table(name: "Options")]
    public class OptionEntity {
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        [Column(name: "option_name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(name: "option_price")]
        public long Price { get; set; }

        [Required]
        [Column(name: "option_quantity")]
        public long Quantity { get; set; }

        [Required]
        [Column(name: "option_sale")]
        public int Sale { get; set; } = 0;

        [ForeignKey("ProductEntityId")]
        public Guid? ProductEntityId { get; set; }

        public ProductEntity ProductEntity { get; set; } = null!;

        [Column(name: "create_at")]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        [Column(name: "update_at")]
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
    }
}