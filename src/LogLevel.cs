namespace NL.Olive.Logging;

/// <summary>
/// Log levels
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// For events that may be interesting during diagnosics and troubleshooting.
    /// </summary>
    Debug,

    /// <summary>
    /// For events that are of interest, but do not fall in any of the other categories.
    /// </summary>
    Info,

    /// <summary>
    /// For events that are unexpected without breaking the work flow, and may require further investigation
    /// </summary>
    Warning,
    /// <summary>
    /// For events that break the work flow and require action
    /// </summary>
    Error
}
