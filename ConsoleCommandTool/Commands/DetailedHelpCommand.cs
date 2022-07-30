﻿namespace ConsoleCommandTool.Commands;

/// <summary>
/// Represents 
/// </summary>
public class DetailedHelpCommand : Command
{
    private readonly Func<string, Command?> _findCommand;

    /// <summary>
    /// Initialize <see cref="DetailedHelpCommand"/> with delegate <paramref name="findCommand"/>
    /// </summary>
    /// <param name="findCommand">Function, that finds command by name</param>
    public DetailedHelpCommand(Func<string, Command?> findCommand)
        : base("help", "help <cmd name>", "Prints command usage and description ")
    {
        _findCommand = findCommand;
    }

    public override void Execute(string[] args, TextWriter writer)
    {
        var commandName = args[1];
        var cmd = _findCommand(commandName);
        if (cmd is null)
        {
            writer.WriteLine($"Sorry, can't find command with name <{commandName}>");
            return;
        }

        writer.WriteLine();
        writer.WriteLine($"{cmd.Usage, 15}\t# {cmd.Description}");
    }
}