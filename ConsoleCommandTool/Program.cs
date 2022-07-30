using ConsoleCommandTool.Commands;
using ConsoleCommandTool.Dispatchers;
using Ninject;
using Ninject.Parameters;

namespace ConsoleCommandTool;

public static class Program
{
    private static ICommandExecutor CreateExecutor()
    {
        var container = new StandardKernel();
        container.Bind<TextWriter>().ToConstant(Console.Out);
        container.Bind<ICommandExecutor>().To<CommandExecutor>();
        container.Bind<Command>().To<PrintTimeCommand>();
        container.Bind<Command>().To<TimerCommand>();
        // executor.Register(new DetailedHelpCommand(new Lazy<Func<string, Command?>>(executor.FindCommand)));
        // executor.Register(new HelpCommand(new Lazy<Func<Command[]>>(executor.GetAvailableCommands)));
        return container.Get<ICommandExecutor>();
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