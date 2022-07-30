using System.Text;

namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents command "h"
/// </summary>
public class HelpCommand : Command
{
    private readonly Command[] _availableCommands;

    public HelpCommand(Command[] availableCommands) 
        : base("h", "h", "Prints name of all available commands to execute")
    {
        _availableCommands = availableCommands;
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        var builder = new StringBuilder();
        builder.Append("Available commands: ");
        foreach (var command in _availableCommands)
        {
            builder.Append($"{command.Name}{Environment.NewLine}");
        }
        writer.WriteLine(builder.ToString());
    }
}