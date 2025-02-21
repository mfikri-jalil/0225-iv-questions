namespace SiliconTesterApp;

/// <inheritdoc cref="IOldTester"/>
public class OldTester : IOldTester
{
    /// <inheritdoc />
    public bool LoadTestProgram()
    {
        // Randomizer to simulate real world behavior where load process sometimes can pass or failed.
        var rand = new Random();
        return rand.Next(10) % 2 == 0;
    }

    /// <inheritdoc />
    public List<int> RunTestProgram()
    {
        // Randomizer to simulate real world data
        var rand = new Random();
        var testResults = new List<int>();
        for (int i = 0; i < 50; i++)
        {
            testResults.Add(rand.Next(100));
        }
        return testResults;
    }

    /// <inheritdoc />
    public bool UnloadTestProgram()
    {
        // Randomizer to simulate real world behavior where unload process sometimes can pass or failed.
        var rand = new Random();
        return rand.Next(10) % 2 == 0;
    }
}
