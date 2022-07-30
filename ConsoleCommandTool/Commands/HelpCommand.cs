namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents command "h"
/// </summary>
public class HelpCommand : Command
{
    public HelpCommand(string name, string usage, string description) : base(name, usage, description)
    {
    }

    /// <summary>
    /// Command, that prints all available commands to execute
    /// </summary>
    /// <param name="textWriter"></param>
    public static void Execute(TextWriter textWriter)
    {
        textWriter.WriteLine("Available commands: timer, printtime, help, h");
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        writer.WriteLine("Available commands: timer, printtime, help, h");
    }
}