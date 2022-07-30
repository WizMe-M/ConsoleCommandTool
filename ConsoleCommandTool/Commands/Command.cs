namespace ConsoleCommandTool.Commands;

public abstract class Command
{
    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="name">Command's name</param>
    /// <param name="usage">Usage example</param>
    /// <param name="description">Description of how command executes</param>
    /// <param name="writer">Text writer to command output</param>
    protected Command(string name, string usage, string description, TextWriter writer)
    {
        Name = name;
        Usage = usage;
        Description = description;
        Writer = writer;
    }

    public string Name { get; }
    public string Usage { get; }
    public string Description { get; }
    
    /// <summary>
    /// <see cref="TextWriter"/> in such command output will be printed
    /// </summary>
    public TextWriter Writer { get; }

    /// <summary>
    /// Executes command with <paramref name="args"/>
    /// </summary>
    /// <param name="args">Command arguments</param>
    public abstract void Execute(string[] args);
}