namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents "printtime" command
/// </summary>
public static class PrintTimeCommand
{
    /// <summary>
    /// Command, that prints current DateTime
    /// </summary>
    public static void ExecutePrintTime()
    {
        Console.WriteLine(DateTime.Now);
    }
}