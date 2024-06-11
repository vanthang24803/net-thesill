using System.Net;
using Api.TheSill.src.domain.enums;

using Newtonsoft.Json;

namespace Api.TheSill.src.common.helpers
{
    public class Response<T>
    {
        [JsonProperty("status")]
        public HttpStatusCode Status { get; set; }
        [JsonProperty("result")]
        public required T Result { get; set; }
    }
}