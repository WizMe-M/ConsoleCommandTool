namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents "timer" command
/// </summary>
public class TimerCommand : Command
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

    public TimerCommand(string name, string usage, string description) : base(name, usage, description)
    {
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        var value = args[1];
        var time = int.Parse(value);
        var timeout = TimeSpan.FromMilliseconds(time);
        writer.WriteLine("Waiting for " + timeout);
        Thread.Sleep(timeout);
        writer.WriteLine("Done!");
    }
}