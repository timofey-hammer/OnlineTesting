using Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Logger;

public class ErrorLoggingMiddleware(RequestDelegate next, ILogger logger)
{

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);

            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                logger.LogNotFound(context);
                await context.Response.WriteAsync("Resource not found.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, context);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsync("An unexpected error occurred.");
        }
    }
}