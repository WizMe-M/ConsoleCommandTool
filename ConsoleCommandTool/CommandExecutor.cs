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
        var command = args[0];
        if (command == "timer")
            TimerCommand.ExecuteTimer(int.Parse(args[1]));
        else if (command == "printtime")
            PrintTimeCommand.ExecutePrintTime();
        else if (command == "h")
            HelpCommand.ExecuteHelp();
        else if (command == "help")
            DetailedHelpCommand.ExecuteDetailedHelp(args[1]);
        else ShowUnknownCommandError(args[0]);
    }

    /// <summary>
    /// Prints input-error
    /// </summary>
    /// <param name="command">Input</param>
    public static void ShowUnknownCommandError(string command)
    {
        Console.WriteLine("Sorry. Unknown command {0}", command);
    }
}