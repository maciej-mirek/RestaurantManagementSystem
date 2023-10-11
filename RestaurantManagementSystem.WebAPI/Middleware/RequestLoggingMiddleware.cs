using Serilog;

namespace RestaurantManagementSystem.WebAPI.Middleware
{
    public class RequestLoggingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Request.EnableBuffering();
            try
            {
                if (context.Request.Body.CanSeek)
                {
                    context.Request.Body.Seek(0, SeekOrigin.Begin);

                    using var reader = new StreamReader(context.Request.Body);
                    var requestBody = await reader.ReadToEndAsync();

                    if (!string.IsNullOrWhiteSpace(requestBody))
                    {
                        Log.ForContext("RequestBody", requestBody).Information("HTTP {@RequestMethod} request to {@RequestPath}", context.Request.Method, context.Request.Path);
                    }

                    context.Request.Body.Seek(0, SeekOrigin.Begin);
                }
            }
            catch(Exception ex)
            {

            }

            await next.Invoke(context);
        }
    
    }
}
