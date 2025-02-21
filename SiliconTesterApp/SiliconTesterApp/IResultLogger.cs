
namespace SiliconTesterApp;

/// <summary>
/// Log test program execution results into a file and console.
/// </summary>
public interface IResultLogger
{
    /// <summary>
    /// Log info message.
    /// </summary>
    /// <param name="message">Information message to log</param>
    void LogInfo(string message);

    /// <summary>
    /// Log warning message.
    /// </summary>
    /// <param name="message">Warning message to log</param>
    void LogWarning(string message);

    /// <summary>
    /// Log error message.
    /// </summary>
    /// <param name="message">Error message to log</param>
    void LogError(string message);    
}
