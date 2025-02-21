namespace SiliconTesterApp;

public class ResultLogger : IResultLogger
{    
    public void LogError(string message)
    {
        File.AppendAllLines("ResultsLog.txt", [message]);
        Console.WriteLine(message + Environment.NewLine);        
    }

    public void LogInfo(string message)
    {
        File.AppendAllLines("ResultsLog.txt", [message]);
        Console.WriteLine(message + Environment.NewLine);
    }

    public void LogWarning(string message)
    {
        File.AppendAllLines("ResultsLog.txt", [message]);
        Console.WriteLine(message + Environment.NewLine);
    }
}

