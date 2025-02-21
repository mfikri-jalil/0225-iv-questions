namespace SiliconTesterApp;

/// <inheritdoc cref="ITestProgramManager"/>
public class TestProgramManager : ITestProgramManager
{
    private readonly IResultLogger resultLogger;
    private readonly IOldTester oldTester;
    private readonly INewTester newTester;

    public TestProgramManager(IResultLogger resultLogger, IOldTester oldTester, INewTester newTester)
    {
        this.resultLogger = resultLogger;
        this.oldTester = oldTester;
        this.newTester = newTester;
    }

    /// <inheritdoc/>
    public void Run(string testerType)
    {
        if (!LoadTestProgram(testerType))
        {
            resultLogger.LogError($"[{DateTime.Now}][ERROR]: Failed to load Test Program");
        }

        var testResults = RunTestProgram(testerType);

        if (!UnloadTestProgram(testerType))
        {
            resultLogger.LogError($"[{DateTime.Now}][ERROR]: Failed to unload Test Program");
        }

        resultLogger.LogInfo($"[{DateTime.Now}][INFO]: Test Results are {string.Join(",", testResults)}");

        var outliers = ExtractOutliers(testResults);
        resultLogger.LogWarning($"[{DateTime.Now}][WARNING]: Outliers are {string.Join(",", outliers)}");

        var localMaximums = ExtractLocalMaximums(testResults);
        resultLogger.LogInfo($"[{DateTime.Now}][INFO]: Local Maximums are {string.Join(",", localMaximums)}");

        var localMinimums = ExtractLocalMinimums(testResults);
        resultLogger.LogInfo($"[{DateTime.Now}][INFO]: Local Minimums are {string.Join(",", localMinimums)}");
    }

    private bool LoadTestProgram(string testerType)
    {
        if (testerType == "new")
        {
            return newTester.LoadTestProgram();
        }
        else if (testerType == "old")
        {
            return oldTester.LoadTestProgram();
        }
        else
        {
            throw new ArgumentException($"{testerType} tester type is invalid.");
        }
    }

    private List<int> RunTestProgram(string testerType)
    {
        if (testerType == "new")
        {
            return newTester.RunTestProgram();
        }
        else if (testerType == "old")
        {
            return oldTester.RunTestProgram();
        }
        else
        {
            throw new ArgumentException($"{testerType} tester type is invalid.");
        }
    }

    private bool UnloadTestProgram(string testerType)
    {
        if (testerType == "new")
        {
            return newTester.UnloadTestProgram();
        }
        else if (testerType == "old")
        {
            return oldTester.UnloadTestProgram();
        }
        else
        {
            throw new ArgumentException($"{testerType} tester type is invalid.");
        }
    }

    /// <summary>
    /// Extract outliers data from test results.
    /// </summary>
    /// <param name="testResults">Raw test results</param>
    /// <returns>Outliers data</returns>
    private List<int> ExtractOutliers(List<int> testResults)
    {
        var outliers = new List<int>();
        var average = testResults.Average();
        foreach (var testResult in testResults)
        {
            if (testResult > 1.2 * average)
            {
                outliers.Add(testResult);
            }
        }
        return outliers;
    }

    /// <summary>
    /// Extract local maximum data from test results.
    /// </summary>
    /// <param name="testResults">Raw test results</param>
    /// <returns>Local maximum data</returns>
    private List<int> ExtractLocalMaximums(List<int> testResults)
    {
        var maximums = new List<int>();
        for (int i = 1; i < testResults.Count - 1; i++)
        {
            if (testResults[i] > testResults[i - 1] && testResults[i] > testResults[i + 1])
            {
                maximums.Add(testResults[i]);
            }
        }
        return maximums;
    }

    /// <summary>
    /// Extract local minimum data from test results.
    /// </summary>
    /// <param name="testResults">Raw test results</param>
    /// <returns>Local minimum data</returns>
    private List<int> ExtractLocalMinimums(List<int> testResults)
    {
        var minimums = new List<int>();
        for (int i = 1; i < testResults.Count - 1; i++)
        {
            if (testResults[i] < testResults[i - 1] && testResults[i] < testResults[i + 1])
            {
                minimums.Add(testResults[i]);
            }
        }     
        return minimums;
    }
}
