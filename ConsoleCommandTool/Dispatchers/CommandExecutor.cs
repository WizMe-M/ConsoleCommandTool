using ConsoleCommandTool.Commands;

namespace ConsoleCommandTool.Dispatchers;

/// <summary>
/// Command dispatcher.
/// <para>Provides correct command execution</para>
/// </summary>
public class CommandExecutor
{
    private readonly List<Command> _commands;

    public CommandExecutor()
    {
        _commands = new List<Command>();
    }

    /// <summary>
    /// Register all available commands
    /// </summary>
    public void RegisterAllCommands()
    {
        _commands.Add(new TimerCommand("timer", "", ""));
        _commands.Add(new PrintTimeCommand("printtime", "", ""));
        _commands.Add(new HelpCommand("h", "", ""));
        _commands.Add(new DetailedHelpCommand("help", "", ""));
    }

    /// <summary>
    /// Executes command, if it exists in command list
    /// </summary>
    /// <param name="args">Command name and arguments</param>
    public void Execute(string[] args)
    {
        var writer = Console.Out;
        var commandName = args[0];
        var cmd = FindCommand(commandName);
        if (cmd is null)
        {
            ShowUnknownCommandError(commandName, writer);
            return;
        }

        cmd.Execute(args, writer);
    }

    /// <summary>
    /// Find command by it's name
    /// </summary>
    /// <param name="commandName">Name of the command</param>
    /// <returns>
    /// <see cref="Command"/> or <c>null</c> if not found
    /// </returns>
    private Command? FindCommand(string commandName) =>
        _commands.FirstOrDefault(cmd => string.Equals(cmd.Name, commandName, StringComparison.OrdinalIgnoreCase));

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