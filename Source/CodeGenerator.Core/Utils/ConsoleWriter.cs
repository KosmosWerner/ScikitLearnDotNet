namespace CodeGenerator.Core.Utils;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string text) => Console.WriteLine(text);
    public void WriteLine() => Console.WriteLine();
    public void Write(string text) => Console.Write(text);
    public void Close() { }
}
