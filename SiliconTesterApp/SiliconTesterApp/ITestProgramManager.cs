namespace SiliconTesterApp;

/// <summary>
/// Manage test program execution.
/// </summary>
public interface ITestProgramManager
{
    /// <summary>
    /// Run Test Program on tester and process test results.
    /// </summary>
    /// <param name="testerType">Either "new" or "old"</param>
    void Run(string testerType);
}


