namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents "timer" command
/// </summary>
public class TimerCommand : Command
{
    public TimerCommand(TextWriter writer) : base("timer", "timer <ms>", "Starts timer for <ms> milliseconds", writer)
    {
    }

    public override void Execute(string[] args)
    {
        var value = args[0];
        if (!int.TryParse(value, out var time))
        {
            Writer.WriteLine($"Argument wasn't a number! Input: \"{value}\"");
            Writer.WriteLine("Please, input valid time in milliseconds");
            return;
        }
        var timeout = TimeSpan.FromMilliseconds(time);
        Writer.WriteLine("Waiting for " + timeout);
        Thread.Sleep(timeout);
        Writer.WriteLine("Done!");
    }
}