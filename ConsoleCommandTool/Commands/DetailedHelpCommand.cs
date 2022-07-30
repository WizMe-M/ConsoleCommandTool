using ConsoleCommandTool.Dispatchers;

namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents 
/// </summary>
public class DetailedHelpCommand : Command
{
    /// <summary>
    /// Command, that prints detailed help of command
    /// </summary>
    /// <param name="commandName">Inputted command</param>
    /// <param name="textWriter"></param>
    public static void Execute(string commandName, TextWriter textWriter)
    {
        textWriter.WriteLine("");
        if (commandName == "timer")
            textWriter.WriteLine("timer <ms> — starts timer for <ms> milliseconds");
        else if (commandName == "printtime")
            textWriter.WriteLine("printtime — prints current time");
        else if (commandName == "h")
            textWriter.WriteLine("h — prints available commands list");
        else if (commandName == "help")
            textWriter.WriteLine("help <command> — prints help for <command>");
        else
        {
            CommandExecutor.ShowUnknownCommandError(commandName, textWriter);
        }
    }

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