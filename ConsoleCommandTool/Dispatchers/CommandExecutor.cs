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
        _commands.Add(new TimerCommand());
        _commands.Add(new PrintTimeCommand());
        _commands.Add(new DetailedHelpCommand(FindCommand));
        _commands.Add(new HelpCommand(GetAvailableCommands));
    }

    public Command[] GetAvailableCommands() => _commands.ToArray();

    /// <summary>
    /// Find command by it's name
    /// </summary>
    /// <returns> <see cref="Command"/> or <c>null</c>, if not found </returns>
    private Command? FindCommand(string commandName) =>
        _commands.FirstOrDefault(cmd => string.Equals(cmd.Name, commandName, StringComparison.OrdinalIgnoreCase));

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
            writer.WriteLine($"Sorry. Unknown command {commandName}");
            return;
        }

        cmd.Execute(args, writer);
    }
}