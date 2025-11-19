using HairSalon.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace HairSalon.Middleware
{
    /// <summary>
    /// Global exception handling middleware
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger,
            IWebHostEnvironment environment)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var (statusCode, message) = exception switch
            {
                NotFoundException => (HttpStatusCode.NotFound, exception.Message),
                BusinessException => (HttpStatusCode.BadRequest, exception.Message),
                ArgumentException => (HttpStatusCode.BadRequest, exception.Message),
                _ => (HttpStatusCode.InternalServerError, "An internal server error occurred.")
            };

            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                StatusCode = (int)statusCode,
                Message = message,
                Detailed = _environment.IsDevelopment() ? exception.ToString() : null
            };

            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }

    /// <summary>
    /// Extension method for adding exception handling middleware
    /// </summary>
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
