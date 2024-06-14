using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.TheSill.src.domain.dtos.token {
    public class RefreshTokenRequest {
        [Required(ErrorMessage = "Token not empty!")]
        [JsonProperty("refresh_token")]
        public required string Token { get; set; }
    }
}