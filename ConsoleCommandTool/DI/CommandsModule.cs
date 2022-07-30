using ConsoleCommandTool.Commands;
using ConsoleCommandTool.Dispatchers;
using ConsoleCommandTool.Writers;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace ConsoleCommandTool.DI;

public class CommandsModule : NinjectModule
{
    public override void Load()
    {
        if (Kernel is null) throw new InvalidOperationException("Kernel was null");
        
        Kernel.Bind(syntax =>
        {
            var commandTypes = syntax.FromThisAssembly().Select(typeof(Command).IsAssignableFrom);
            commandTypes.BindAllBaseClasses().Configure(c => c.InSingletonScope());
        });
        Kernel.Bind<ICommandExecutor>().To<CommandExecutor>().InSingletonScope();
        
        Kernel.Bind<TextWriter>().To<RedConsoleWriter>()
            .WhenInjectedInto<CommandExecutor>().InSingletonScope();
        Kernel.Bind<TextWriter>().To<PromptConsoleWriter>()
            .WhenInjectedInto<Command>().InSingletonScope();
    }
}