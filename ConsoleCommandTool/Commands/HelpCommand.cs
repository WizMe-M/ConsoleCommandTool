namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents command "h"
/// </summary>
public static class HelpCommand
{
    /// <summary>
    /// Command, that prints all available commands to execute
    /// </summary>
    /// <param name="textWriter"></param>
    public static void Execute(TextWriter textWriter)
    {
        textWriter.WriteLine("Available commands: timer, printtime, help, h");
    }
}