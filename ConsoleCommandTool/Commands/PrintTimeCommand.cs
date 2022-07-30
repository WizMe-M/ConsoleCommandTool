namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents "printtime" command
/// </summary>
public class PrintTimeCommand : Command
{
    public PrintTimeCommand(string name, string usage, string description) : base(name, usage, description)
    {
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        writer.WriteLine(DateTime.Now);
    }
}