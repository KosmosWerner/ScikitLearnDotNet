using Python.Runtime;
using Python.Included;
using Numpy;
using ScikitLearn;

namespace ConsoleExample
{
    internal class Program
    {
        private static async Task InitializeInstallerAsync()
        {
            Installer.InstallPath = Path.GetFullPath(".");

            await Installer.SetupPython();
            await Installer.TryInstallPip();
            await Installer.PipInstallModule("numpy");
            await Installer.PipInstallModule("scikit-learn");
        }

        static void Main(string[] args)
        {
            Task.Run(InitializeInstallerAsync).Wait();


            var X = np.array(new int[,] {
                { 1, 2 }, { 2, 2 }, { 2, 3 },
                { 8, 7 }, { 8,8 }, { 25, 25 } });

            var clustering = new sklearn.cluster.DBSCAN(eps: 3, min_samples: 2).fit(X);
            Console.WriteLine(clustering.labels_);
        }
    }
}
