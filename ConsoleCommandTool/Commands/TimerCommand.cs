namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents "timer" command
/// </summary>
public class TimerCommand : Command
{
    public TimerCommand() : base("timer", "timer <ms>", "Starts timer for <ms> milliseconds")
    {
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        var value = args[0];
        if (!int.TryParse(value, out var time))
        {
            writer.WriteLine($"Argument wasn't a number! Input: \"{value}\"");
            writer.WriteLine("Please, input valid time in milliseconds");
            return;
        }
        var timeout = TimeSpan.FromMilliseconds(time);
        writer.WriteLine("Waiting for " + timeout);
        Thread.Sleep(timeout);
        writer.WriteLine("Done!");
    }
}