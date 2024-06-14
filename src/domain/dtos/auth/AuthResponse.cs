using Api.TheSill.src.domain.dtos.role;

namespace Api.TheSill.src.domain.dtos.auth {
    public class AuthResponse {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Avatar { get; set; }

        public bool Verify { get; set; } = false;

        public List<RoleResponse> Roles { get; set; } = [];

        public DateTime CreateAt { get; set; }


    }
}