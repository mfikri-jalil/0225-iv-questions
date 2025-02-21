namespace SiliconTesterApp;

/// <summary>
/// Tester that can provide only 50 test results points per run.
/// </summary>
public interface IOldTester
{
    /// <summary>
    /// Load Test Program to Tester.
    /// </summary>
    /// <returns>True if load was succesful</returns>
    bool LoadTestProgram();

    /// <summary>
    /// Run loaded Test Program.
    /// </summary>
    /// <returns>List of test results</returns>
    List<int> RunTestProgram();

    /// <summary>
    /// Unload Test Program from tester.
    /// </summary>
    /// <returns>True if unload was succesful.</returns>
    bool UnloadTestProgram();
}
