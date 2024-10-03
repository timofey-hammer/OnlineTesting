using Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Logger;

public class ConsoleLogger : ILogger
{
    public void LogError(Exception ex, HttpContext context)
    {
        Console.WriteLine("----- Error Logging -----");
        Console.WriteLine($"Timestamp: {DateTime.UtcNow}");
        Console.WriteLine($"Request Path: {context.Request.Path}");
        Console.WriteLine($"Exception: {ex.Message}");
        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        Console.WriteLine("-----------------------------------");
    }

    public void LogNotFound(HttpContext context)
    {
        Console.WriteLine("----- 404 Not Found -----");
        Console.WriteLine($"Timestamp: {DateTime.UtcNow}");
        Console.WriteLine($"Request Path: {context.Request.Path}");
        Console.WriteLine("-----------------------------------");
    }
}