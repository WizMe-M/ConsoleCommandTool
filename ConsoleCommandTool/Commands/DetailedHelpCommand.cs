using ConsoleCommandTool.Dispatchers;

namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents 
/// </summary>
public class DetailedHelpCommand : Command
{
    public DetailedHelpCommand(string name, string usage, string description) : base(name, usage, description)
    {
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        var commandName = args[1];
        writer.WriteLine("");

        if (commandName == "timer")
            writer.WriteLine("timer <ms> — starts timer for <ms> milliseconds");
        else if (commandName == "printtime")
            writer.WriteLine("printtime — prints current time");
        else if (commandName == "h")
            writer.WriteLine("h — prints available commands list");
        else if (commandName == "help")
            writer.WriteLine("help <command> — prints help for <command>");
        else
        {
            CommandExecutor.ShowUnknownCommandError(commandName, writer);
        }
    }
}