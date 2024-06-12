using Newtonsoft.Json;

namespace Api.TheSill.src.domain.dtos.token {
    public class TokenResponse {

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; } = string.Empty;

        [JsonProperty("access_token")]
        public string AccessToken { get; set; } = string.Empty;

    }
}