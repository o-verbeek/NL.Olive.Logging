namespace NL.Olive.Logging;

/// <summary>
/// A logger with the possibility of changing an external configuration file and updating the log level at run time.
/// </summary>
public class ConfigurableLogger : Logger, IDisposable
{
    private readonly string _configFileName;
    private readonly FileWatcher _configFileWatcher;

    private static readonly string[] ValidLogLevelValues = Enum.GetNames(typeof(LogLevel));

    public ConfigurableLogger(string filePath, string fileName, string configurationFileName) 
        : base(filePath, fileName)
    {
        this._configFileName = configurationFileName;
        this._configFileWatcher = new FileWatcher(this._configFileName);
        this._configFileWatcher.FileChanged += this.OnConfigChanged;
    }

    private LogLevel GetLogLevelFromConfigFile()
    {
        var logLevelValue = ConfigurationFileReader.GetProperty(this._configFileName, "LogLevel");
        if (Enum.TryParse(logLevelValue, ignoreCase: true, out LogLevel result))
            return result;

        //If we get an invalid logLevelValue, log it as a warning. LogLevel remains unchanged.
        LogWarning($"Value {logLevelValue} is not a valid LogLevel. Options are: <{string.Join(", ", ValidLogLevelValues)}>. LogLevel remains {this.LogLevel}");
        return this.LogLevel;
    }

    private void OnConfigChanged(object? sender, FileSystemEventArgs e)
    {
        var newLogLevel = this.GetLogLevelFromConfigFile();
        if (newLogLevel != this.LogLevel)
            this.SetLogLevel(newLogLevel);
    }

    public void Dispose()
    {
        this._configFileWatcher.FileChanged -= this.OnConfigChanged;
        this._configFileWatcher?.Dispose();
    }
}
