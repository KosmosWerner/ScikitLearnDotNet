namespace CodeGenerator.Utils;

public interface IWriter
{
    void WriteLine(string text);
    void WriteLine();
    void Write(string text);
    void Close();
}
