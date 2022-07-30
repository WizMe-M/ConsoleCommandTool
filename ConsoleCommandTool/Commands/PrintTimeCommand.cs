namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents "printtime" command
/// </summary>
public class PrintTimeCommand : Command
{
    public PrintTimeCommand(TextWriter writer) : base("printtime", "printtime", "Prints current time", writer)
    {
    }

    public override void Execute(string[] args)
    {
        Writer.WriteLine(DateTime.Now);
    }
}