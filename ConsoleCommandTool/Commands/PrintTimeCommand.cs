namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents "printtime" command
/// </summary>
public static class PrintTimeCommand
{
    /// <summary>
    /// Command, that prints current DateTime
    /// </summary>
    /// <param name="textWriter"></param>
    public static void ExecutePrintTime(TextWriter textWriter)
    {
        textWriter.WriteLine(DateTime.Now);
    }
}