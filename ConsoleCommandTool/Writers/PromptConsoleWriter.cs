using System.Text;

namespace ConsoleCommandTool.Writers;

public class PromptConsoleWriter : TextWriter
{
    public override Encoding Encoding => Console.Out.Encoding;
    public override void WriteLine(string? value)
    {
        Console.Out.WriteLine($"> {value}");
    }
}