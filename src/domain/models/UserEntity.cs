using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.TheSill.src.domain.models {
    [Table("users")]
    public class UserEntity {
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        [Column(name: "first_name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column(name: "last_name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column(name: "email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column(name: "password", TypeName = "TEXT")]
        public string Password { get; set; } = string.Empty;

        [Column(name: "avatar", TypeName = "TEXT")]
        public string Avatar { get; set; } = string.Empty;

        [Column(name: "verify")]
        public bool VerifyEmail { get; set; }

        [Column(name: "refresh_token", TypeName = "TEXT")]
        public string RefreshToken { get; set; } = string.Empty;

        public List<RoleEntity> Roles { get; } = [];

        [Column(name: "create_at")]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    }
}