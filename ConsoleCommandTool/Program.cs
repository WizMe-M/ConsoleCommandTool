using ConsoleCommandTool.Commands;
using ConsoleCommandTool.Dispatchers;
using ConsoleCommandTool.Writers;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Parameters;

namespace ConsoleCommandTool;

public static class Program
{
    private static ICommandExecutor CreateExecutor()
    {
        var container = new StandardKernel();
        container.Bind(syntax => syntax.FromThisAssembly().SelectAllClasses().BindAllBaseClasses());
        container.Bind(syntax => syntax.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
        
        container.Bind<TextWriter>().To<RedConsoleWriter>()
            .WhenInjectedInto<CommandExecutor>();
        container.Bind<TextWriter>().To<PromptConsoleWriter>()
            .WhenInjectedInto<Command>();

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