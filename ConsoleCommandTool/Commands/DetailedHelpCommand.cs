using ConsoleCommandTool.Dispatchers;

namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents 
/// </summary>
public class DetailedHelpCommand : Command
{
    private readonly Lazy<ICommandExecutor> _executor;

    /// <summary>
    /// Initialize <see cref="DetailedHelpCommand"/> with lazy <paramref name="executor"/>
    /// </summary>
    /// <param name="executor"><see cref="Lazy{T}"/> ICommandExecutor, that contains method FindCommand by name</param>
    public DetailedHelpCommand(Lazy<ICommandExecutor> executor)
        : base("help", "help <cmd name>", "Prints command usage and description ")
    {
        _executor = executor;
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        var commandName = args[0];
        var cmd = _executor.Value.FindCommand(commandName);
        if (cmd is null)
        {
            writer.WriteLine($"Sorry, can't find command with name <{commandName}>");
            return;
        }

        writer.WriteLine();
        writer.WriteLine($"{cmd.Usage, 15}\t# {cmd.Description}");
    }
}