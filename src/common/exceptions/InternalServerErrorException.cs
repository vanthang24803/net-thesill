using System.Net;
namespace Api.TheSill.src.common.exceptions {
    public class InternalServerErrorException(string message = "Internal Server Error") : Exception(message) {
        public ApiError ToApiError() {
            return new ApiError {
                Status = (int)HttpStatusCode.InternalServerError,
                Message = Message,
                Timestamp = DateTime.Now
            };
        }
    }
}