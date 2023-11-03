namespace NL.Olive.Logging;

/// <summary>
/// An interface for the logger
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Gets the log level
    /// </summary>
    /// <param name="logLevel"></param>
    LogLevel LogLevel { get; }

    /// <summary>
    /// Sets the log level
    /// </summary>
    /// <param name="level"></param>
    void SetLogLevel(LogLevel level);

    /// <summary>
    /// Logs the message if the log level is set to debug
    /// </summary>
    /// <param name="message"></param>
    void LogDebug(string message);

    /// <summary>
    /// Logs the message if the log level is set to info, or lower
    /// </summary>
    /// <param name="message"></param>
    void LogInfo(string message);

    /// <summary>
    /// Logs the message if the log level is set to warning, or lower
    /// </summary>
    /// <param name="message"></param>
    void LogWarning(string message);

    /// <summary>
    /// Logs the message if the log level is set to error, or lower
    /// </summary>
    /// <param name="message"></param>
    void LogError(string message);
}
