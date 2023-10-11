


using RestaurantManagementSystem.Domain.Exceptions;

namespace RestaurantManagementSystem.WebAPI.Middleware
{
    public class ExceptionsMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "application/json";
                var errorResponse = new ErrorResponse
                {
                    Message = notFoundException.Message,
                    StatusCode = StatusCodes.Status404NotFound
                };
                await context.Response.WriteAsync(errorResponse.ToString());

            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var errorResponse = new ErrorResponse
                {
                    Message = "Internal Server Error",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                await context.Response.WriteAsync(errorResponse.ToString());

            }
        }
    }
}
