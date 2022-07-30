namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents command "h"
/// </summary>
public static class HelpCommand
{
    /// <summary>
    /// Command, that prints all available commands to execute
    /// </summary>
    public static void ExecuteHelp()
    {
        Console.WriteLine("Available commands: timer, printtime, help, h");
    }
}