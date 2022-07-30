using ConsoleCommandTool.Commands;

namespace ConsoleCommandTool.Dispatchers;

/// <summary>
/// Command dispatcher.
/// <para>Provides correct command execution</para>
/// </summary>
public class CommandExecutor : ICommandExecutor
{
    private readonly TextWriter _writer;
    private readonly Command[] _commands;

    public CommandExecutor(Command[] commands, TextWriter writer)
    {
        _writer = writer;
        _commands = commands;
    }

    /// <inheritdoc/>
    public Command[] GetAvailableCommands() => _commands.ToArray();

    /// <inheritdoc/>
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
        cmd.Execute(commandArguments);
    }
}