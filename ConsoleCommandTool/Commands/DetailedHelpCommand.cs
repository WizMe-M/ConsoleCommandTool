namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents 
/// </summary>
public static class DetailedHelpCommand
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
}