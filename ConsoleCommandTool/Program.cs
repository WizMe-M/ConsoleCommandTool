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
            RunCommand(args);
        else
            RunInteractiveMode();
    }

    /// <summary>
    /// Runs inputted command
    /// </summary>
    /// <param name="args">Command and it's argument</param>
    private static void RunCommand(string[] args)
    {
        var command = args[0];
        if (command == "timer")
            ExecuteTimer(int.Parse(args[1]));
        else if (command == "printtime")
            ExecutePrintTime();
        else if (command == "h")
            ExecuteHelp();
        else if (command == "help")
            ExecuteDetailedHelp(args[1]);
        else ShowUnknownCommandError(args[0]);
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
            RunCommand(line.Split(' '));
        }
    }

    /// <summary>
    /// Command, that prints all available commands to execute
    /// </summary>
    private static void ExecuteHelp()
    {
        Console.WriteLine("Available commands: timer, printtime, help, h");
    }

    /// <summary>
    /// Prints input-error
    /// </summary>
    /// <param name="command">Input</param>
    private static void ShowUnknownCommandError(string command)
    {
        Console.WriteLine("Sorry. Unknown command {0}", command);
    }

    /// <summary>
    /// Command, that prints current DateTime
    /// </summary>
    private static void ExecutePrintTime()
    {
        Console.WriteLine(DateTime.Now);
    }

    /// <summary>
    /// Command, that freeze application on inputted time (ms)
    /// </summary>
    /// <param name="time"></param>
    private static void ExecuteTimer(int time)
    {
        var timeout = TimeSpan.FromMilliseconds(time);
        Console.WriteLine("Waiting for " + timeout);
        Thread.Sleep(timeout);
        Console.WriteLine("Done!");
    }

    /// <summary>
    /// Command, that prints detailed help of command
    /// </summary>
    /// <param name="commandName">Inputted command</param>
    private static void ExecuteDetailedHelp(string commandName)
    {
        Console.WriteLine("");
        if (commandName == "timer")
            Console.WriteLine("timer <ms> — starts timer for <ms> milliseconds");
        else if (commandName == "printtime")
            Console.WriteLine("printtime — prints current time");
        else if (commandName == "h")
            Console.WriteLine("h — prints available commands list");
        else if (commandName == "help")
            Console.WriteLine("help <command> — prints help for <command>");
        else
        {
            ShowUnknownCommandError(commandName);
        }
    }
}