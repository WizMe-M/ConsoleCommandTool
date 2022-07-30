using System.Text;
using ConsoleCommandTool.Dispatchers;

namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents command "h"
/// </summary>
public class HelpCommand : Command
{
    private readonly Lazy<ICommandExecutor> _executor;

    public HelpCommand(TextWriter writer, Lazy<ICommandExecutor> executor) 
        : base("h", "h", "Prints name of all available commands to execute", writer)
    {
        _executor = executor;
    }

    public override void Execute(string[] args)
    {
        var commands = _executor.Value.GetAvailableCommands();
        var builder = new StringBuilder();
        builder.Append("Available commands:\n");
        foreach (var command in commands)
        {
            builder.Append($"{command.Name}{Environment.NewLine}");
        }
        Writer.WriteLine(builder.ToString());
    }
}