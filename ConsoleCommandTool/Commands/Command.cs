namespace ConsoleCommandTool.Commands;

public abstract class Command
{
    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="name">Command's name</param>
    /// <param name="usage">Usage example</param>
    /// <param name="description">Description of how command executes</param>
    protected Command(string name, string usage, string description)
    {
        Name = name;
        Usage = usage;
        Description = description;
    }

    public string Name { get; }
    public string Usage { get; }
    public string Description { get; }

    /// <summary>
    /// Executes command with <paramref name="args"/> in <paramref name="writer"/>
    /// </summary>
    /// <param name="args">Command arguments</param>
    /// <param name="writer">Writer, that will print all command output</param>
    public abstract void Execute(string[] args, TextWriter writer);
}