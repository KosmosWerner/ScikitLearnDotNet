using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.Core.Utils;

namespace CodeGenerator.Core
{
    internal class GeneratorWriter
    {
        private static readonly string[] usings =
        [
            "Numpy",
            "Python.Runtime",
        ];

        private readonly IWriter writer;
        private readonly string current_namespace;
        private readonly string current_static_class;
        private readonly string fixed_namespace;
        private readonly int total_lines;
        private bool printedHeaders = false;
        public GeneratorWriter(IWriter writer, string current_namespace, int total_lines)
        {
            this.writer = writer;
            this.current_namespace = current_namespace;
            current_static_class = current_namespace.Split(".")[^1];
            if (names.Contains(current_static_class)) current_static_class = "@" + current_static_class;
            if (current_namespace.Split(".")[^1] != current_static_class)
            {
                fixed_namespace = current_namespace.Replace(".", ".@");
            }
            else
            {
                fixed_namespace = current_namespace;
            }
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

        HashSet<string> names = new(
        [
            "abstract",
            "as",
            "base",
            "bool",
            "break",
            "byte",
            "case",
            "catch",
            "char",
            "checked",
            "class",
            "const",
            "continue",
            "decimal",
            "default",
            "delegate",
            "do",
            "double",
            "else",
            "enum",
            "event",
            "explicit",
            "extern",
            "false",
            "finally",
            "fixed",
            "float",
            "for",
            "foreach",
            "goto",
            "if",
            "implicit",
            "in",
            "int",
            "interface",
            "internal",
            "is",
            "lock",
            "long",
            "namespace",
            "new",
            "null",
            "object",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "readonly",
            "ref",
            "return",
            "sbyte",
            "sealed",
            "short",
            "sizeof",
            "stackalloc",
            "static",
            "string",
            "struct",
            "switch",
            "this",
            "throw",
            "true",
            "try",
            "typeof",
            "uint",
            "ulong",
            "unchecked",
            "unsafe",
            "ushort",
            "using",
            "virtual",
            "void",
            "volatile",
            "while",
        ]);

        private void PrintClassStart()
        {
            writer.WriteLine("public static partial class sklearn");
            writer.WriteLine("{");

            if (current_namespace != current_static_class)
            {
                writer.WriteLine($"\tpublic static class {current_static_class}");
                writer.WriteLine("\t{");
            }
        }

        private void PrintImportModules()
        {
            writer.WriteLine("\t\tprivate static Lazy<PyObject> _lazy_self;");
            writer.WriteLine();
            writer.WriteLine("\t\tpublic static PyObject self => _lazy_self.Value;");
            writer.WriteLine();
            writer.WriteLine($"\t\tstatic {current_static_class}() => ReInitializeLazySelf();");
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
            writer.WriteLine($"\t\t\treturn Py.Import(\"{current_namespace}\");");
            writer.WriteLine("\t\t}");
            writer.WriteLine();
        }

        public void PrintStartStaticClass()
        {
            if (!printedHeaders)
            {
                PrintUsings();
                PrintNamespace();
                PrintClassStart();
                PrintImportModules();
                printedHeaders = true;
            }
        }

        public void PrintEndStaticClass()
        {
            if (current_namespace != current_static_class)
            {
                writer.WriteLine("\t}");
            }
            writer.WriteLine("}");
        }

        public void PrintStartClass(string class_name)
        {
            writer.WriteLine($"\t\tpublic class {class_name} : PythonObject");
            writer.WriteLine("\t\t{");
        }

        public void PrintEndClass()
        {
            writer.WriteLine("\t\t}");
            writer.WriteLine();
        }


        public void PrintParamsList(
            Dictionary<string, string> param_args,
            Dictionary<string, string> param_kw,
            Dictionary<string, string> param_types)
        {
            int total = param_args.Count + param_kw.Count;
            int i = 0;
            foreach (var item in param_args)
            {
                i++;
                if (param_types.TryGetValue(item.Key, out string? type))
                {
                    if (string.IsNullOrEmpty(item.Value)) writer.Write($"{type} {item.Key}");
                    else writer.Write($"{type} {item.Key} = {item.Value}");
                    if (i != total) writer.Write(", ");
                }
            }
            foreach (var item in param_kw)
            {
                i++;
                if (param_types.TryGetValue(item.Key, out string? type))
                {
                    if (string.IsNullOrEmpty(item.Value)) writer.Write($"{type} {item.Key}");
                    else writer.Write($"{type} {item.Key} = {item.Value}");
                    if (i != total) writer.Write(", ");
                }
            }
        }

        public void PrintInvokableArguments(
            Dictionary<string, string> param_args,
            Dictionary<string, string> param_kw,
            Dictionary<string, string> param_types)
        {
            if (param_args.Count > 0)
            {
                string args = string.Join(", ", param_args.Select(x => x.Key).ToArray());
                writer.WriteLine($"\t\t\t\tPyTuple args = ToTuple(new object[] {{{args}}});");
            }
            else
            {
                writer.WriteLine("\t\t\t\tPyTuple args = new PyTuple();");
            }

            writer.WriteLine("\t\t\t\tPyDict pyDict = new PyDict();");

            foreach (var item in param_kw)
            {
                var type = param_types[item.Key];
                if (type.EndsWith('?'))
                {
                    writer.WriteLine($"\t\t\t\tif ({item.Key} != null)");
                    writer.WriteLine("\t\t\t\t{");
                    writer.WriteLine($"\t\t\t\t\tpyDict[\"{item.Key}\"] = ToPython({item.Key});");
                    writer.WriteLine("\t\t\t\t}");
                }
                else
                {
                    writer.WriteLine($"\t\t\t\tpyDict[\"{item.Key}\"] = ToPython({item.Key});");
                }
            }
        }


        public void PrintConstructor(
            string class_name,
            Dictionary<string, string> ctor_args,
            Dictionary<string, string> ctor_kw,
            Dictionary<string, string> ctor_param_types)
        {
            writer.Write($"\t\t\tpublic {class_name}(");
            PrintParamsList(ctor_args, ctor_kw, ctor_param_types);
            writer.WriteLine(")");

            writer.WriteLine("\t\t\t{");

            PrintInvokableArguments(ctor_args, ctor_kw, ctor_param_types);
            writer.WriteLine($"\t\t\t\tself = {fixed_namespace}.self.InvokeMethod(\"{class_name}\", args, pyDict);");


            writer.WriteLine("\t\t\t}");
            writer.WriteLine();
        }

        public void PrintMethods(
            string method_name,
            Dictionary<string, string> method_args,
            Dictionary<string, string> method_kw,
            Dictionary<string, string> method_types,
            string return_type,
            bool self = false)
        {
            writer.Write($"\t\t\tpublic {return_type} {method_name}(");
            PrintParamsList(method_args, method_kw, method_types);
            writer.WriteLine(")");

            writer.WriteLine("\t\t\t{");
            PrintInvokableArguments(method_args, method_kw, method_types);

            if (self)
            {
                writer.WriteLine($"\t\t\t\tself.InvokeMethod(\"{method_name}\", args, pyDict);");
                writer.WriteLine("\t\t\t\treturn this;");
            }
            else
            {
                writer.WriteLine($"\t\t\t\tPyObject result = self.InvokeMethod(\"{method_name}\", args, pyDict);");

                if (return_type == "PyObject")
                    writer.WriteLine($"\t\t\t\treturn result;");
                else
                    writer.WriteLine($"\t\t\t\treturn ToCsharp<{return_type}>(result);");
            }

            writer.WriteLine("\t\t\t}");
            writer.WriteLine();
        }

        public void PrintAttributes(Dictionary<string, string[]> attributes)
        {
            foreach (var (key, types) in attributes)
            {
                string result = types.Length switch
                {
                    1 => types[0] == "PyObject"
                        ? $"\t\t\tpublic PyObject {key} => self.GetAttr(\"{key}\");"
                        : $"\t\t\tpublic {types[0]} {key} => ToCsharp<{types[0]}>(self.GetAttr(\"{key}\"));",

                    2 when types.Contains("NDarray") && (types.Contains("bool") || types.Contains("int") || types.Contains("float"))
                        => $"\t\t\tpublic NDarray {key} => ToCsharp<NDarray>(self.GetAttr(\"{key}\"));",

                    _ => throw new ArgumentException($"PrintAttributes: Unable to convert {string.Join(", ", types)}")
                };

                writer.WriteLine(result);
                writer.WriteLine();
            }
        }
    }
}
