using Numpy;
using Python.Included;
using Python.Runtime;
using ScikitLearn;
using ScottPlot;
using ScottPlot.WPF;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace ExampleCluster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double[] coordinates1x;
        double[] coordinates1y;

        double[] coordinates2x;
        double[] coordinates2y;

        double[] coordinates3x;
        double[] coordinates3y;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;

            Task.Run(InitializeInstallerAsync).Wait();
            GenerateRandomPoints();
            GenerateRandomGroups();
            GenerateRanomCircles();
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            PythonEngine.Shutdown();
        }

        readonly Random random = new(42);

        private static async Task InitializeInstallerAsync()
        {
            Installer.InstallPath = Path.GetFullPath(".");

            await Installer.SetupPython();
            await Installer.TryInstallPip();
            await Installer.PipInstallModule("numpy");
            await Installer.PipInstallModule("scikit-learn");
        }

        public void GenerateRandomPoints()
        {
            int count = 300;
            coordinates1x = new double[count];
            coordinates1y = new double[count];
            for (int i = 0; i < count; i++)
            {
                coordinates1x[i] = -10 + random.NextDouble() * 20;
                coordinates1y[i] = -10 + random.NextDouble() * 20;
            }

            DrawRandomPoints(coordinates1x, coordinates1y, plotDbcan1, plotOptics1, plotMean1);
        }

        public void GenerateRandomGroups()
        {
            int count = 300;
            coordinates2x = new double[count];
            coordinates2y = new double[count];

            for (int i = 0; i < 4; i++)
            {
                double x = -7.5 + random.NextDouble() * 15;
                double y = -7.5 + random.NextDouble() * 15;

                for (int j = i * 75; j < i * 75 + 75; j++)
                {
                    double angle = 2 * random.NextDouble() * Math.PI;
                    coordinates2x[j] = x + random.NextDouble() * 5 * Math.Cos(angle);
                    coordinates2y[j] = y + random.NextDouble() * 5 * Math.Sin(angle);
                }
            }

            DrawRandomPoints(coordinates2x, coordinates2y, plotDbcan2, plotOptics2, plotMean2);
        }

        public void GenerateRanomCircles()
        {
            coordinates3x = new double[400];
            coordinates3y = new double[400];

            for (int i = 0; i < 100; i++)
            {
                double angle = 2 * random.NextDouble() * Math.PI;
                coordinates3x[i] = (1 + random.NextDouble() * 1) * Math.Cos(angle);
                coordinates3y[i] = (1 + random.NextDouble() * 1) * Math.Sin(angle);
            }

            for (int i = 100; i < 400; i++)
            {
                double angle = 2 * random.NextDouble() * Math.PI;
                coordinates3x[i] = (10 + random.NextDouble() * 2) * Math.Cos(angle);
                coordinates3y[i] = (10 + random.NextDouble() * 2) * Math.Sin(angle);
            }

            DrawRandomPoints(coordinates3x, coordinates3y, plotDbcan3, plotOptics3, plotMean3);
        }

        private void ButtonGenerate_Click(object sender, RoutedEventArgs e)
        {
            GenerateRandomPoints();
            GenerateRandomGroups();
            GenerateRanomCircles();
        }

        private void ClasifyBDSCAN(double[] _xs, double[] _ys, WpfPlot plot)
        {
            var xs = np.array(_xs);
            var ys = np.array(_ys);

            NDarray X = np.vstack(xs, ys).T;
            var model = new sklearn.cluster.DBSCAN(eps: (float)eps.Value, min_samples: 5);

            NDarray labels = model.fit_predict(X);

            var tags = labels.GetData<long>();
            var min = tags.Min();
            var max = tags.Max();

            plot.Plot.Clear();
            for (var i = min; i <= max; i++)
            {
                List<double> lx = [];
                List<double> ly = [];

                for (int j = 0; j < tags.Length; j++)
                {
                    if (tags[j] == i)
                    {
                        lx.Add(_xs[j]);
                        ly.Add(_ys[j]);
                    }
                }

                plot.Plot.Add.ScatterPoints(lx, ly, color: (i == -1) ? ScottPlot.Colors.Gray : ScottPlot.Color.RandomHue());
            }

            plot.Refresh();
        }

        private void ClasifyOPTICS(double[] _xs, double[] _ys, WpfPlot plot)
        {
            var xs = np.array(_xs);
            var ys = np.array(_ys);

            NDarray X = np.vstack(xs, ys).T;

            var model = new sklearn.cluster.OPTICS(min_samples: 2).fit(X);

            NDarray labels = model.labels_;
            var tags = labels.GetData<long>();
            var min = tags.Min();
            var max = tags.Max();


            plot.Plot.Clear();
            for (var i = min; i <= max; i++)
            {
                List<double> lx = [];
                List<double> ly = [];

                for (int j = 0; j < tags.Length; j++)
                {
                    if (tags[j] == i)
                    {
                        lx.Add(_xs[j]);
                        ly.Add(_ys[j]);
                    }
                }


                plot.Plot.Add.ScatterPoints(lx, ly, color: (i == -1) ? ScottPlot.Colors.Gray : ScottPlot.Color.RandomHue());
            }

            plot.Refresh();
        }

        private void ClasifyMeanShift(double[] _xs, double[] _ys, WpfPlot plot)
        {
            var xs = np.array(_xs);
            var ys = np.array(_ys);

            NDarray X = np.vstack(xs, ys).T;

            var model = new sklearn.cluster.MeanShift(bandwidth: 2).fit(X);

            NDarray labels = model.labels_;
            var tags = labels.GetData<long>();
            var min = tags.Min();
            var max = tags.Max();


            plot.Plot.Clear();
            for (var i = min; i <= max; i++)
            {
                List<double> lx = [];
                List<double> ly = [];

                for (int j = 0; j < tags.Length; j++)
                {
                    if (tags[j] == i)
                    {
                        lx.Add(_xs[j]);
                        ly.Add(_ys[j]);
                    }
                }


                plot.Plot.Add.ScatterPoints(lx, ly, color: (i == -1) ? ScottPlot.Colors.Gray : ScottPlot.Color.RandomHue());
            }

            plot.Refresh();
        }

        private void ButtonClasify_Click(object sender, RoutedEventArgs e)
        {
            ClasifyBDSCAN(coordinates1x, coordinates1y, plotDbcan1);
            ClasifyBDSCAN(coordinates2x, coordinates2y, plotDbcan2);
            ClasifyBDSCAN(coordinates3x, coordinates3y, plotDbcan3);

            ClasifyOPTICS(coordinates1x, coordinates1y, plotOptics1);
            ClasifyOPTICS(coordinates2x, coordinates2y, plotOptics2);
            ClasifyOPTICS(coordinates3x, coordinates3y, plotOptics3);

            ClasifyMeanShift(coordinates1x, coordinates1y, plotMean1);
            ClasifyMeanShift(coordinates2x, coordinates2y, plotMean2);
            ClasifyMeanShift(coordinates3x, coordinates3y, plotMean3);
        }

        private void DrawRandomPoints(double[] coordinatesx, double[] coordinatesy, WpfPlot plotDbcan, WpfPlot plotOptics, WpfPlot plotMean, bool clear = true)
        {
            if (clear)
            {
                plotDbcan.Plot.Clear();
                plotOptics.Plot.Clear();
                plotMean.Plot.Clear();
            }
            plotDbcan.Plot.Add.ScatterPoints(coordinatesx, coordinatesy);
            plotOptics.Plot.Add.ScatterPoints(coordinatesx, coordinatesy);
            plotMean.Plot.Add.ScatterPoints(coordinatesx, coordinatesy);
            plotDbcan.Refresh();
            plotOptics.Refresh();
            plotMean.Refresh();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            plotDbcan1.Plot.Axes.Link(plotOptics1);
            plotDbcan1.Plot.Axes.Link(plotMean1);

            plotOptics1.Plot.Axes.Link(plotDbcan1);
            plotOptics1.Plot.Axes.Link(plotMean1);

            plotMean1.Plot.Axes.Link(plotDbcan1);
            plotMean1.Plot.Axes.Link(plotOptics1);



            plotDbcan2.Plot.Axes.Link(plotOptics2);
            plotDbcan2.Plot.Axes.Link(plotMean2);

            plotOptics2.Plot.Axes.Link(plotDbcan2);
            plotOptics2.Plot.Axes.Link(plotMean2);

            plotMean2.Plot.Axes.Link(plotDbcan2);
            plotMean2.Plot.Axes.Link(plotOptics2);


            plotDbcan3.Plot.Axes.Link(plotOptics3);
            plotDbcan3.Plot.Axes.Link(plotMean3);

            plotOptics3.Plot.Axes.Link(plotDbcan3);
            plotOptics3.Plot.Axes.Link(plotMean3);

            plotMean3.Plot.Axes.Link(plotDbcan3);
            plotMean3.Plot.Axes.Link(plotOptics3);
        }
    }
}