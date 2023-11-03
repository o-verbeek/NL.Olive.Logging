namespace NL.Olive.Logging;

/// <summary>
/// A simple logger
/// </summary>
public class Logger : ILogger
{
    private LogLevel _logLevel;
    private readonly string _filePath;
    private readonly string _fileName;
            
    /// <summary>
    /// Default constructor
    /// </summary>
    public Logger(string filePath, string fileName, LogLevel logLevel)
    {
        this._logLevel = logLevel;
        this._filePath = filePath;
        this._fileName = fileName;
    }
    
    protected Logger(string filePath, string fileName)
    {
        this._filePath = filePath;
        this._fileName = fileName;
    }

    public LogLevel LogLevel { 
        get => this._logLevel; 
        private set
        {
            this._logLevel = value;
            LogDebug($"Log level set to {value}");
        }
    }

    public void LogDebug(string message)
    {
        this.ConditionallyLogMessage(message, LogLevel.Debug);
    }

    public void LogError(string message)
    {
        this.ConditionallyLogMessage(message, LogLevel.Error);
    }

    public void LogInfo(string message)
    {
        this.ConditionallyLogMessage(message, LogLevel.Info);
    }

    public void LogWarning(string message)
    {
        this.ConditionallyLogMessage(message, LogLevel.Warning);
    }

    private void ConditionallyLogMessage(string message, LogLevel logLevel)
    {
        if (this.LogLevel > logLevel)
            return;

        LogMessage(message);
    }

    public void SetLogLevel(LogLevel newLogLevel)
    {
        this.LogLevel = newLogLevel;
    }

    private void LogMessage(string message)
    {
        var constructedMessage = this.ConstructLogMessage(message);
        var file = Path.Combine(this._filePath, this._fileName);
        using var writer = new StreamWriter(file, append: true);
        writer.WriteLine(constructedMessage);
    }

    private string ConstructLogMessage(string message)
    {
        var dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var logMessage = string.Format("{0}:: ({1}): {2}", dateTime, this.LogLevel.ToString(), message);
        return logMessage;
    }
}
