namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents "timer" command
/// </summary>
public static class TimerCommand
{
    /// <summary>
    /// Command, that freeze application on inputted time (ms)
    /// </summary>
    /// <param name="time">Time in milliseconds</param>
    public static void ExecuteTimer(int time)
    {
        var timeout = TimeSpan.FromMilliseconds(time);
        Console.WriteLine("Waiting for " + timeout);
        Thread.Sleep(timeout);
        Console.WriteLine("Done!");
    }
}