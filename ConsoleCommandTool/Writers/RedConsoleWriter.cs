using System.Text;

namespace ConsoleCommandTool.Writers;

public class RedConsoleWriter : TextWriter
{
    public override Encoding Encoding => Console.Out.Encoding;
    public override void Write(char value)
    {
        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Out.Write(value);
        Console.ForegroundColor = previousColor;
    }
}