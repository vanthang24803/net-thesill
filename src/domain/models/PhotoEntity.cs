using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.TheSill.src.domain.models {
    [Table(name: "Photos")]
    public class PhotoEntity {
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column(name: "photo_url", TypeName = "TEXT")]
        public string Url { get; set; } = string.Empty;

        [ForeignKey("ProductEntityId")]
        public Guid? ProductEntityId { get; set; }

        public ProductEntity ProductEntity { get; set; } = null!;

        [Column(name: "create_at")]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}