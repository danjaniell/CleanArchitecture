using CleanArchitecture.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Logger;

public class AppLogger<T>(ILogger<T> logger) : IAppLogger<T>
{
    public void Log(LogLevel logLevel, string logMessage)
    {
        logger.Log(logLevel, logMessage);
    }

    public void Log(LogLevel logLevel, string logMessage, string exceptionMessage, Exception exception)
    {
        logger.Log(logLevel, exception, $"{logMessage} | Exception: {exceptionMessage}");
    }

    public void Log(LogLevel logLevel, string logMessage, Dictionary<string, string> enrichers)
    {
        using (logger.BeginScope(enrichers))
        {
            logger.Log(logLevel, logMessage);
        }
    }

    public void Log(LogLevel logLevel, string logMessage, string exceptionMessage, Exception exception, Dictionary<string, string> enrichers)
    {
        using (logger.BeginScope(enrichers))
        {
            logger.Log(logLevel, exception, $"{logMessage} | Exception: {exceptionMessage}");
        }
    }

    public void LogInformation(string message, Dictionary<string, string>? enrichers = null)
    {
        if (enrichers is not null)
            Log(LogLevel.Information, message, enrichers);
        else
            Log(LogLevel.Information, message);
    }

    public void LogWarning(string message, Dictionary<string, string>? enrichers = null)
    {
        if (enrichers is not null)
            Log(LogLevel.Warning, message, enrichers);
        else
            Log(LogLevel.Warning, message);
    }

    public void LogError(string exceptionMessage, Exception exception, Dictionary<string, string>? enrichers = null)
    {
        if (enrichers is not null)
            Log(LogLevel.Error, "An error occurred", exceptionMessage, exception, enrichers);
        else
            Log(LogLevel.Error, "An error occurred", exceptionMessage, exception);
    }

    public void LogCritical(string exceptionMessage, Exception exception, Dictionary<string, string>? enrichers = null)
    {
        if (enrichers is not null)
            Log(LogLevel.Critical, "A critical error occurred", exceptionMessage, exception, enrichers);
        else
            Log(LogLevel.Critical, "A critical error occurred", exceptionMessage, exception);
    }
}
