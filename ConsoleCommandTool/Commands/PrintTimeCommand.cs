namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents "printtime" command
/// </summary>
public class PrintTimeCommand : Command
{
    /// <summary>
    /// Command, that prints current DateTime
    /// </summary>
    /// <param name="textWriter"></param>
    public static void Execute(TextWriter textWriter)
    {
        textWriter.WriteLine(DateTime.Now);
    }

    public PrintTimeCommand(string name, string usage, string description) : base(name, usage, description)
    {
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        writer.WriteLine(DateTime.Now);
    }
}