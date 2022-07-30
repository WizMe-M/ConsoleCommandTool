using ConsoleCommandTool.Commands;

namespace ConsoleCommandTool;

/// <summary>
/// Command dispatcher.
/// <para>Provides correct command execution</para>
/// </summary>
public static class CommandExecutor
{
    /// <summary>
    /// Runs inputted command
    /// <para>Also it knows about all commands, existing in app</para>>
    /// </summary>
    /// <param name="args">Command and it's argument</param>
    public static void RunCommand(string[] args)
    {
        var writer = Console.Out;
        var command = args[0];

        if (command == "timer")
            TimerCommand.Execute(int.Parse(args[1]), writer);
        else if (command == "printtime")
            PrintTimeCommand.Execute(writer);
        else if (command == "h")
            HelpCommand.Execute(writer);
        else if (command == "help")
            DetailedHelpCommand.Execute(args[1], writer);
        else ShowUnknownCommandError(args[0], writer);
    }

    /// <summary>
    /// Prints input-error
    /// </summary>
    /// <param name="command">Input</param>
    /// <param name="textWriter"></param>
    public static void ShowUnknownCommandError(string command, TextWriter textWriter)
    {
        textWriter.WriteLine("Sorry. Unknown command {0}", command);
    }
}