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
    /// <param name="textWriter"></param>
    public static void Execute(int time, TextWriter textWriter)
    {
        var timeout = TimeSpan.FromMilliseconds(time);
        textWriter.WriteLine("Waiting for " + timeout);
        Thread.Sleep(timeout);
        textWriter.WriteLine("Done!");
    }
}