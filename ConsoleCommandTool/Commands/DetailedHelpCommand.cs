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
    public static void ExecuteDetailedHelp(string commandName)
    {
        Console.WriteLine("");
        if (commandName == "timer")
            Console.WriteLine("timer <ms> — starts timer for <ms> milliseconds");
        else if (commandName == "printtime")
            Console.WriteLine("printtime — prints current time");
        else if (commandName == "h")
            Console.WriteLine("h — prints available commands list");
        else if (commandName == "help")
            Console.WriteLine("help <command> — prints help for <command>");
        else
        {
            CommandExecutor.ShowUnknownCommandError(commandName);
        }
    }
}