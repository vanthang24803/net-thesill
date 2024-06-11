using Newtonsoft.Json;

namespace Api.TheSill.src.common.exceptions
{
    public class ErrorHandlingMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionAsync(context, ex, 400);

            }
            catch (UnauthorizedException ex)
            {
                await HandleExceptionAsync(context, ex, 401);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, ex, 404);
            }
            catch (ForbiddenException ex)
            {
                await HandleExceptionAsync(context, ex, 403);
            }
            catch (InternalServerErrorException ex)
            {
                await HandleExceptionAsync(context, ex, 500);
            }

        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var errorResponse = new ApiError
            {
                Status = statusCode,
                Message = exception.Message,
                Timestamp = DateTime.Now
            };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}