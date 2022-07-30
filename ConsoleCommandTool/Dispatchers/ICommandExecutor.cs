using ConsoleCommandTool.Commands;

namespace ConsoleCommandTool.Dispatchers;

public interface ICommandExecutor
{
    /// <summary>
    /// Executes some command with <see cref="args"/>
    /// </summary>
    /// <param name="args">Execution arguments including command name</param>
    void Execute(string[] args);
    
    /// <summary>
    /// Find command by it's name
    /// </summary>
    /// <returns> <see cref="Command"/> or <c>null</c>, if not found </returns>
    Command? FindCommand(string commandName);

    /// <summary>
    /// Get all available commands in executor
    /// </summary>
    public Command[] GetAvailableCommands();
}