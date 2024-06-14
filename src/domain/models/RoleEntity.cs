using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.TheSill.src.domain.enums;

namespace Api.TheSill.src.domain.models {
    [Table("roles")]
    public class RoleEntity {
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        [Column(name: "role_name")]
        public Role Role { get; set; } = Role.CUSTOMER;

        public List<UserEntity> Users { get; set; } = [];

        [Column(name: "create_at")]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        [Column(name: "update_at")]
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

    }
}