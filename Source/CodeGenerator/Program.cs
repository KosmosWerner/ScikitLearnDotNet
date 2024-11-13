namespace CodeGenerator;

internal class Program
{
    public static async Task Main(string[] args)
    {
        //var urls = await UriSearcher.Search("https://scikit-learn.org/stable/api/sklearn.html");

        //List<Uri> urls =
        //[
        //    new ("https://scikit-learn.org/stable/modules/generated/sklearn.cluster.AffinityPropagation.html"),
        //    new ("https://scikit-learn.org/stable/modules/generated/sklearn.cluster.AgglomerativeClustering.html"),
        //    new ("https://scikit-learn.org/stable/modules/generated/sklearn.cluster.Birch.html"),
        //    new ("https://scikit-learn.org/stable/modules/generated/sklearn.cluster.BisectingKMeans.html"),
        //    new ("https://scikit-learn.org/stable/modules/generated/sklearn.cluster.DBSCAN.html"),
        //    new ("https://scikit-learn.org/stable/modules/generated/sklearn.cluster.KMeans.html"),
        //];

        Console.WriteLine(typeof((float, int)).);
        Type t = typeof((float, int));

        //await Generator.GenerateFrom(urls);

        // Console.WriteLine("OK");
        //await Generator.GenerateFromNamespace("sklearn.cluster", urls);
    }
}
