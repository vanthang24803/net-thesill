using System.Net;
namespace Api.TheSill.src.common.exceptions
{
    public class UnauthorizedException(string message = "Unauthorized") : Exception(message)
    {
        public ApiError ToApiError()
        {
            return new ApiError
            {
                Status = (int)HttpStatusCode.Unauthorized,
                Message = Message,
                Timestamp = DateTime.Now
            };
        }
    }
}