using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.Utils;

namespace CodeGenerator
{
    internal class GeneratorWriter
    {
        private static readonly string[] usings =
        [
            "Numpy",
            "Python.Runtime",
        ];

        private readonly IWriter writer;
        private readonly string currentNamespace;
        private readonly string currentClass;
        private readonly int total_lines;
        private bool printedHeaders = false;
        public GeneratorWriter(IWriter writer, string currentNamespace, int total_lines)
        {
            this.writer = writer;
            this.currentNamespace = currentNamespace;
            this.currentClass = currentNamespace.Split(".")[^1];
            this.total_lines = total_lines;
        }


        private void PrintUsings()
        {
            foreach (var us in usings)
            {
                writer.WriteLine($"using {us};");
            }

            writer.WriteLine();
        }

        private void PrintNamespace()
        {
            writer.WriteLine("namespace ScikitLearn;");
            writer.WriteLine();
        }

        private void PrinClassStart()
        {
            writer.WriteLine("public static partial class sklearn");
            writer.WriteLine("{");

            if (currentNamespace != currentClass)
            {
                writer.WriteLine($"\tpublic static class {currentClass}");
                writer.WriteLine("\t{");
            }
        }

        private void PrintImportModules()
        {
            writer.WriteLine("\t\tprivate static Lazy<PyObject> _lazy_self;");
            writer.WriteLine();
            writer.WriteLine("\t\tpublic static PyObject self => _lazy_self.Value;");
            writer.WriteLine();
            writer.WriteLine($"\t\tstatic {currentClass}() => ReInitializeLazySelf();");
            writer.WriteLine();
            writer.WriteLine("\t\tprivate static void ReInitializeLazySelf()");
            writer.WriteLine("\t\t{");
            writer.WriteLine("\t\t\t_lazy_self = new Lazy<PyObject>(delegate");
            writer.WriteLine("\t\t\t{");
            writer.WriteLine("\t\t\t\ttry { return InstallAndImport(); }");
            writer.WriteLine("\t\t\t\tcatch (Exception) { return InstallAndImport(force: true); }");
            writer.WriteLine("\t\t\t});");
            writer.WriteLine("\t\t}");
            writer.WriteLine();
            writer.WriteLine("\t\tprivate static PyObject InstallAndImport(bool force = false)");
            writer.WriteLine("\t\t{");
            writer.WriteLine("\t\t\tPythonEngine.AddShutdownHandler(ReInitializeLazySelf);");
            writer.WriteLine("\t\t\tPythonEngine.Initialize();");
            writer.WriteLine($"\t\t\treturn Py.Import(\"{currentNamespace}\");");
            writer.WriteLine("\t\t}");
            writer.WriteLine();
        }

        public void PrintHeaderOneTime()
        {
            if (!printedHeaders)
            {
                PrintUsings();
                PrintNamespace();
                PrinClassStart();
                PrintImportModules();
                printedHeaders = true;
            }
        }

        public void PrintClose(int current_line)
        {
            if (current_line == total_lines)
            {
                if (currentNamespace != currentClass)
                {
                    writer.WriteLine("\t}");
                }
                writer.WriteLine("}");
            }
        }
    }
}
