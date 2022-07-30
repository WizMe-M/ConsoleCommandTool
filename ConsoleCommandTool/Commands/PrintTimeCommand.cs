namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents "printtime" command
/// </summary>
public class PrintTimeCommand : Command
{
    public PrintTimeCommand() : base("printtime", "printtime", "")
    {
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        writer.WriteLine(DateTime.Now);
    }
}