using ConsoleCommandTool.Commands;

namespace ConsoleCommandTool.Dispatchers;

public interface ICommandExecutor
{
    /// <summary>
    /// Registers new command in executor list
    /// </summary>
    void Register(Command command);
    
    /// <summary>
    /// Executes some command with <see cref="args"/>
    /// </summary>
    /// <param name="args">Execution arguments including command name</param>
    void Execute(string[] args);
}