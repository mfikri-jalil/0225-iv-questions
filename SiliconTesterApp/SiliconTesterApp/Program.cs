using SiliconTesterApp;

public class Program
{
    /// <summary>
    /// A console application that run a test program and log the results into a file. 
    /// </summary>
    /// <param name="args">New or old. By default is new</param>
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services
            .AddTransient<ITestProgramManager, TestProgramManager>()
            .AddTransient<IOldTester, OldTester>()
            .AddTransient<INewTester, NewTester>()
            .AddTransient<IResultLogger, ResultLogger>();
        var host = builder.Build();
        var testProgramManager = host.Services.GetRequiredService<ITestProgramManager>();
        var testerType = "new";
        testProgramManager.Run(testerType);
    }
}

