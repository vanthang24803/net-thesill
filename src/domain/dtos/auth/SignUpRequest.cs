using System.ComponentModel.DataAnnotations;

namespace Api.TheSill.src.domain.dtos.auth {
    public class SignUpRequest {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Email must be between 1 and 255 characters")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }
}