using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Domain.Interfaces;

public interface IAppLogger<T>
{
    void Log(LogLevel logLevel, string logMessage);
    void Log(LogLevel logLevel, string logMessage, string exceptionMessage, Exception exception);
    void Log(LogLevel logLevel, string logMessage, Dictionary<string, string> enrichers);
    void Log(LogLevel logLevel, string logMessage, string exceptionMessage, Exception exception, Dictionary<string, string> enrichers);

    void LogInformation(string message, Dictionary<string, string>? enrichers = null);
    void LogWarning(string message, Dictionary<string, string>? enrichers = null);
    void LogError(string exceptionMessage, Exception exception, Dictionary<string, string>? enrichers = null);
    void LogCritical(string exceptionMessage, Exception exception, Dictionary<string, string>? enrichers = null);
}
