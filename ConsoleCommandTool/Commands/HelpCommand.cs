namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents command "h"
/// </summary>
public class HelpCommand : Command
{
    public HelpCommand(string name, string usage, string description) : base(name, usage, description)
    {
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        writer.WriteLine("Available commands: timer, printtime, help, h");
    }
}