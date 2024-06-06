
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Domain.ExceptionHandler
{
    public class AppExceptionHandler() : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = new ResponseBase()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Result = exception.Message,
                Title = "Error Processing"
            };
            await httpContext.Response.WriteAsJsonAsync(response,cancellationToken);

            return true;
        }
    }
}
