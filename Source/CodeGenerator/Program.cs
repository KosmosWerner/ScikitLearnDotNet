using CodeGenerator.Core;

namespace CodeGenerator;

internal class Program
{
    public static async Task Main(string[] args)
    {
        string currentPath = Path.GetFullPath(".");
        string destinationPath = Path.GetFullPath(Path.Combine(currentPath, "..", "..", "..", "..", "ScikitLearn"));

        var urls = await UriSearcher.Search("https://scikit-learn.org/stable/api/sklearn.html");
        await Generator.CreatePreGenerated(urls, destinationPath);

        Generator.CreateGenerated(destinationPath);
    }
}
