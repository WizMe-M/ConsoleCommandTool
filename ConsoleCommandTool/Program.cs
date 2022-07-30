namespace ConsoleCommandTool;

public static class Program
{
    /// <summary>
    /// Configures app launch mode
    /// </summary>
    /// <param name="args">Some program arguments</param>
    public static void Main(string[] args)
    {
        if (args.Length > 0)
            CommandExecutor.RunCommand(args);
        else
            RunInteractiveMode();
    }

    /// <summary>
    /// Provides application run until it'll get "exit" or empty input
    /// </summary>
    public static void RunInteractiveMode()
    {
        while (true)
        {
            var line = Console.ReadLine();
            if (line == null || line == "exit") return;
            CommandExecutor.RunCommand(line.Split(' '));
        }
    }
}