﻿using ConsoleCommandTool.Commands;
using ConsoleCommandTool.Dispatchers;
using ConsoleCommandTool.Locator;

namespace ConsoleCommandTool;

public static class Program
{
    private static ICommandExecutor CreateExecutor()
    {
        ServiceLocator.Instance.Register(Console.Out);
        var writerService = ServiceLocator.Instance.GetService<TextWriter>();
        var executor = new CommandExecutor(writerService);
        executor.Register(new TimerCommand());
        executor.Register(new PrintTimeCommand());
        executor.Register(new DetailedHelpCommand(executor.FindCommand));
        executor.Register(new HelpCommand(executor.GetAvailableCommands));
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