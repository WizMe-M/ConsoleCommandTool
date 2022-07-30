using ConsoleCommandTool.Commands;
using ConsoleCommandTool.Dispatchers;
using ConsoleCommandTool.Writers;
using Ninject;
using Ninject.Parameters;

namespace ConsoleCommandTool;

public static class Program
{
    private static ICommandExecutor CreateExecutor()
    {
        var container = new StandardKernel();
        container.Bind<TextWriter>().To<RedConsoleWriter>()
            .Named("error");
        container.Bind<TextWriter>().To<PromptConsoleWriter>()
            .WhenInjectedInto<Command>();
         
        container.Bind<Command>().To<PrintTimeCommand>();
        container.Bind<Command>().To<TimerCommand>();
        container.Bind<Command>().To<DetailedHelpCommand>();
        container.Bind<Command>().To<HelpCommand>();
        
        container.Bind<ICommandExecutor>().To<CommandExecutor>().InSingletonScope();
        
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