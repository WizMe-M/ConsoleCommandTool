namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents "timer" command
/// </summary>
public class TimerCommand : Command
{
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