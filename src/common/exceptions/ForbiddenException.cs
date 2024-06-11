using System.Net;
namespace Api.TheSill.src.common.exceptions {
    public class ForbiddenException(string message = "Forbidden") : Exception(message) {
        public ApiError ToApiError() {
            return new ApiError {
                Status = (int)HttpStatusCode.Forbidden,
                Message = Message,
                Timestamp = DateTime.Now
            };
        }
    }
}