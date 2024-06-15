using Newtonsoft.Json;

namespace Api.TheSill.src.common.exceptions {
    public class ApiError {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("timestamp")]
        public DateTime Timestamp = DateTime.Now;

        public ApiError() {
        }
    }
}