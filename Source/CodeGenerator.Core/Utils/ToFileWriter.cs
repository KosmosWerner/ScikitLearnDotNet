namespace CodeGenerator.Core.Utils;

public class ToFileWriter : IWriter
{
    private readonly StreamWriter stream;
    public ToFileWriter(string path)
    {
        stream = new(path)
        {
            AutoFlush = true
        };
    }

    public void Write(string text) => stream.Write(text);
    public void WriteLine(string text) => stream.WriteLine(text);
    public void WriteLine() => stream.WriteLine();
    public void Close() => stream.Close();
}
