using BusinessLogicLayer.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace ProductsMicroService.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;



        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException ex)
            {
                httpContext.Response.StatusCode = 404;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    message = ex.Message
                });


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");

                httpContext.Response.StatusCode = 500;

                await httpContext.Response.WriteAsJsonAsync(new
                {
                    Message = "An unexpected error occurred.",
                    Type = ex.GetType().Name
                });

            }
        }
    }
}
