using System.Net;
using Newtonsoft.Json;

namespace Api.TheSill.src.common.helpers {
    public class Response<T>(HttpStatusCode status, T result) {
        [JsonProperty("status")]
        public HttpStatusCode Status { get; set; } = status;

        [JsonProperty("result")]
        public T Result { get; set; } = result;
    }
}
