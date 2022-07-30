using ConsoleCommandTool.Commands;
using ConsoleCommandTool.Dispatchers;
using Ninject;

namespace ConsoleCommandTool;

public static class Program
{
    private static ICommandExecutor CreateExecutor()
    {
        var container = new StandardKernel();
        container.Bind<TextWriter>().ToConstant(Console.Out);
        var writer = container.Get<TextWriter>();
        
        var executor = new CommandExecutor(Array.Empty<Command>(), writer);
        // executor.Register(new TimerCommand());
        // executor.Register(new PrintTimeCommand());
        // executor.Register(new DetailedHelpCommand(new Lazy<Func<string, Command?>>(executor.FindCommand)));
        // executor.Register(new HelpCommand(new Lazy<Func<Command[]>>(executor.GetAvailableCommands)));
        return executor;
    }
    
    
    /// <summary>
    /// Configures app launch mode
    /// </summary>
    /// <param name="args">Some program arguments</param>
    public static void Main(string[] args)
    {
        var commandExecutor = CreateExecutor();
        
        if (args.Length > 0)
            commandExecutor.Execute(args);
        else
            RunInteractiveMode(commandExecutor);
    }

    /// <summary>
    /// Provides application run until it'll get "exit" or empty input
    /// </summary>
    private static void RunInteractiveMode(ICommandExecutor executor)
    {
        while (true)
        {
            var line = Console.ReadLine();
            if (line == null || line == "exit") return;
            executor.Execute(line.Split(' '));
        }
    }
}