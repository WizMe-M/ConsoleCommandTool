using System.Text;

namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents command "h"
/// </summary>
public class HelpCommand : Command
{
    private readonly Func<Command[]> _getAvailableCommands;

    public HelpCommand(Func<Command[]> getAvailableCommands) 
        : base("h", "h", "Prints name of all available commands to execute")
    {
        _getAvailableCommands = getAvailableCommands;
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        var commands = _getAvailableCommands();
        var builder = new StringBuilder();
        builder.Append("Available commands:\n");
        foreach (var command in commands)
        {
            builder.Append($"{command.Name}{Environment.NewLine}");
        }
        writer.WriteLine(builder.ToString());
    }
}