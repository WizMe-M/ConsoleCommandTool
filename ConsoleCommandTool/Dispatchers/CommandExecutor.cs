using ConsoleCommandTool.Commands;

namespace ConsoleCommandTool.Dispatchers;

/// <summary>
/// Command dispatcher.
/// <para>Provides correct command execution</para>
/// </summary>
public class CommandExecutor : ICommandExecutor
{
    private readonly TextWriter _writer;
    private readonly List<Command> _commands;

    public CommandExecutor(TextWriter writer)
    {
        _writer = writer;
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
        var commandName = args[0];
        var cmd = FindCommand(commandName);
        if (cmd is null)
        {
            _writer.WriteLine($"Sorry. Unknown command {commandName}");
            return;
        }

        var commandArguments = args.Skip(1).ToArray();
        cmd.Execute(commandArguments, _writer);
    }
}