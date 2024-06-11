namespace Api.TheSill.src.common.exceptions
{
    public class InternalServerErrorException(string message = "Internal Server Error") : Exception(message)
    {
        public ApiError ToApiError()
        {
            return new ApiError
            {
                Status = 500,
                Message = Message, 
                Timestamp = DateTime.Now
            };
        }
    }
}