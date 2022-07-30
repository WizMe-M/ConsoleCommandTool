using ConsoleCommandTool.Commands;

namespace ConsoleCommandTool.Dispatchers;

/// <summary>
/// Command dispatcher.
/// <para>Provides correct command execution</para>
/// </summary>
public class CommandExecutor : ICommandExecutor
{
    private readonly List<Command> _commands;

    public CommandExecutor()
    {
        _commands = new List<Command>();
    }

    /// <inheritdoc/>
    public void Register(Command command) => _commands.Add(command);

    public Command[] GetAvailableCommands() => _commands.ToArray();

    /// <summary>
    /// Find command by it's name
    /// </summary>
    /// <returns> <see cref="Command"/> or <c>null</c>, if not found </returns>
    public Command? FindCommand(string commandName) =>
        _commands.FirstOrDefault(cmd => string.Equals(cmd.Name, commandName, StringComparison.OrdinalIgnoreCase));

    /// <inheritdoc/>
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