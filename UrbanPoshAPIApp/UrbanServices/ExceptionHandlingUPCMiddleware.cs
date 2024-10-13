using System.Net;

namespace UrbanPoshAPIApp.UrbanServices
{
    public class ExceptionHandlingUPCMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingUPCMiddleware> _logger;

        public ExceptionHandlingUPCMiddleware(RequestDelegate next, ILogger<ExceptionHandlingUPCMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");

            var result = new
            {
                error = ex.Message,
                // Optionally log the stack trace, but be cautious with exposing it to clients
                stackTrace = ex.StackTrace
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
