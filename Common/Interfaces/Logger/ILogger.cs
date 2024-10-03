using Microsoft.AspNetCore.Http;

namespace Common.Interfaces;

public interface ILogger
{
    void LogNotFound(HttpContext context);
    void LogError(Exception ex, HttpContext context);
}