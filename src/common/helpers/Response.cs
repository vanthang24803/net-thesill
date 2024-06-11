using Newtonsoft.Json;

namespace Api.TheSill.src.common.helpers
{
    public class Response<T>
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("result")]
        public required T Result { get; set; }
    }
}