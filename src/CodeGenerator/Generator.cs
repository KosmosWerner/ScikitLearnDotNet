using CodeGenerator.Utils;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeGenerator;

internal static partial class Generator
{
    public static async Task GenerateFrom(Dictionary<string, List<Uri>> source)
    {
        foreach (var pair in source)
        {
            await GenerateFromNamespace(pair.Key, pair.Value);
        }
    }

    public static async Task GenerateFromNamespace(string currentNamespace, List<Uri> urls)
    {
        string folderName = "src";
        string fileName = currentNamespace + ".cs";
        string path = Path.Combine(Path.GetFullPath("."), folderName, fileName);

        //IWriter writer = new ToFileWriter(path);
        IWriter writer = new ConsoleWriter();

        GeneratorWriter genWriter = new(writer, currentNamespace, urls.Count);

        int current_line = 0;

        foreach (var url in urls)
        {
            current_line++;
            using HttpClient client = new();

            try
            {
                string pageContent = await client.GetStringAsync(url);

                HtmlDocument htmlDoc = new();
                htmlDoc.LoadHtml(pageContent);

                var _container = htmlDoc.DocumentNode.SelectSingleNode("//*[contains(@class, 'bd-article')]");
                if (_container == null)
                {
                    genWriter.PrintClose(current_line);
                    return;
                }

                /////////////////////////////
                //// General Description ////
                /////////////////////////////

                var _use_description = _container.SelectSingleNode(".//*[contains(@class, 'sig sig-object py')]");
                if (_use_description == null)
                {
                    genWriter.PrintClose(current_line);
                    return;
                }

                //// Is Class ////
                var is_class = _container.SelectSingleNode(".//*[contains(@class, 'property')]");
                if (is_class == null)
                {
                    genWriter.PrintClose(current_line);
                    return;
                }

                //// Namespace ////
                var full_namespace = _use_description.SelectSingleNode(".//*[contains(@class, 'sig-prename descclassname')]")?.InnerText;
                if (full_namespace == null) return;
                full_namespace = full_namespace.EndsWith('.') ? full_namespace[..^1] : full_namespace;

                string[] namespace_root = full_namespace.Replace(" ", "").Split(".");
                string namespace_sklearn = namespace_root[0];
                string namespace_library = namespace_root[^1];
                string import_library = string.Join(".", namespace_root);



                genWriter.PrintHeaderOneTime();



                //// Class Name ////
                var class_name = _use_description.SelectSingleNode(".//*[contains(@class, 'sig-name descname')]")?.InnerText;
                if (class_name == null) return;

                writer.WriteLine($"\t\tpublic class {class_name} : PythonObject");
                writer.WriteLine("\t\t{");

                ///////////////////////
                ////  Constructor  ////
                ///////////////////////

                Dictionary<string, string?> ctor_args = [];
                Dictionary<string, string?> ctor_kw = [];
                Dictionary<string, string> ctor_types = [];
                bool ctor_is_arg = true;

                //// Default Args ////
                var _ctor_params = _use_description.SelectNodes(".//*[contains(@class, 'sig-param')]");
                if (_ctor_params != null)
                {
                    // Exists constructor params: default value
                    foreach (var _param in _ctor_params)
                    {
                        var param_operator = _param.SelectSingleNode(".//*[contains(@class, 'o')]")?.InnerText;
                        var param_name = _param.SelectSingleNode(".//*[contains(@class, 'n')]")?.InnerText;
                        var param_default = _param.SelectSingleNode(".//*[contains(@class, 'default_value')]")?.InnerText;

                        GeneratorMapper.MethodParams.AssignDefaultValues(
                            param_operator,
                            param_name,
                            param_default,
                            ref ctor_is_arg,
                            ctor_args,
                            ctor_kw);
                    }
                }
                else
                {
                    // No exists constructor params: default value
                }

                var _ctor_types_and_fields = _container.SelectSingleNode(".//*[contains(@class, 'field-list') and not(ancestor::*/ancestor::*[contains(@class, 'py method')])]");

                if (_ctor_types_and_fields != null)
                {
                    // Exists constructor params types and class fields

                    /////////////////////////////
                    ////  Constructor Types  ////
                    /////////////////////////////

                    var _ctor_types_section = _ctor_types_and_fields.SelectNodes(".//*[contains(@class, 'field-odd')]");
                    if (_ctor_types_section != null)
                    {
                        // Check
                        if (_ctor_types_section[0].InnerText == "Parameters")
                        {
                            var _param_types = _ctor_types_section[1].SelectNodes(".//dt");
                            if (_param_types != null)
                            {
                                foreach (var item in _param_types)
                                {
                                    var param_name = item.SelectSingleNode(".//strong")?.InnerText;
                                    var param_type = item.SelectSingleNode(".//span")?.InnerText;

                                    GeneratorMapper.MethodParams.AssignTypes(
                                        param_name,
                                        param_type,
                                        ctor_args,
                                        ctor_kw,
                                        ctor_types);
                                }
                            }

                            PrintConstructor(writer, class_name, namespace_library, ctor_args, ctor_kw, ctor_types);
                        }
                        else
                        {
                            throw new ArgumentException($"field-odd isn't Parameters: {_ctor_types_section[0].InnerText}\");");

                        }
                    }

                    //////////////////////
                    ////  Attributes  ////
                    //////////////////////

                    var _attributes_section = _ctor_types_and_fields.SelectNodes(".//*[contains(@class, 'field-even')]");
                    if (_attributes_section != null)
                    {
                        Dictionary<string, string[]> class_fields = [];
                        // Check
                        if (_attributes_section[0].InnerText == "Attributes")
                        {
                            var _attribute = _attributes_section[1].SelectNodes(".//dt");
                            if (_attribute != null)
                            {
                                foreach (var _property in _attribute)
                                {
                                    var property_name = _property.SelectSingleNode(".//strong")?.InnerText;
                                    var property_type = _property.SelectSingleNode(".//span")?.InnerText;

                                    GeneratorMapper.Attributes.AssignTypes(
                                        class_fields,
                                        property_name,
                                        property_type);
                                }
                            }

                            PrintProperties(writer, class_fields);
                        }
                        else
                        {

                            throw new ArgumentException($"field-even isn't Parameters: {_attributes_section[0].InnerText}\");");
                        }
                    }
                }
                else
                {
                    // No exists constructor params types and class fields
                    PrintConstructor(writer, class_name, namespace_library, ctor_args, ctor_kw, ctor_types);
                }


                ///////////////////
                ////  Methods  ////
                ///////////////////

                var _method_containers = _container.SelectNodes(".//*[contains(@class, 'py method')]");
                if (_method_containers != null)
                {
                    // Exists Methods

                    foreach (var _method_container in _method_containers)
                    {
                        var _declaration = _method_container.SelectSingleNode(".//*[contains(@class, 'sig sig-object py')]");
                        if (_declaration == null) throw new ArgumentException("Method without declaration example");

                        var _method_name = _declaration.SelectSingleNode(".//*[contains(@class, 'sig-name descname')]")?.InnerText;
                        if (_method_name == null) throw new ArgumentException("Method without name");

                        //// Default Args ////
                        Dictionary<string, string?> method_args = [];
                        Dictionary<string, string?> method_kw = [];
                        Dictionary<string, string> method_types = [];
                        bool method_is_arg = true;

                        var _method_params = _declaration.SelectNodes(".//*[contains(@class, 'sig-param')]");
                        if (_method_params != null)
                        {
                            // Exists params: default value
                            foreach (var _param in _method_params)
                            {
                                var param_operator = _param.SelectSingleNode(".//*[contains(@class, 'o')]")?.InnerText;
                                var param_name = _param.SelectSingleNode(".//*[contains(@class, 'n')]")?.InnerText;
                                var param_default = _param.SelectSingleNode(".//*[contains(@class, 'default_value')]")?.InnerText;

                                GeneratorMapper.MethodParams.AssignDefaultValues(
                                    param_operator,
                                    param_name,
                                    param_default,
                                    ref method_is_arg,
                                    method_args,
                                    method_kw);
                            }
                        }
                        else
                        {
                            // Not Exists params: default value
                        }

                        //// Args Types ////
                        var _params_section = _method_container.SelectNodes(".//*[contains(@class, 'field-odd')]");
                        if (_params_section != null)
                        {
                            if (_params_section[0].InnerText != "Parameters") throw new ArgumentException($"Method field-odd isn't Parameters: {_params_section[0].InnerText}");

                            var _param_info_types = _params_section[1].SelectNodes(".//dt");
                            if (_param_info_types != null)
                            {
                                foreach (var item in _param_info_types)
                                {
                                    var param_name = item.SelectSingleNode(".//strong")?.InnerText;
                                    var param_type = item.SelectSingleNode(".//span")?.InnerText;

                                    GeneratorMapper.MethodParams.AssignTypes(
                                        param_name,
                                        param_type,
                                        method_args,
                                        method_kw,
                                        method_types);
                                }
                            }
                        }

                        //// Return Type ////
                        var _return_section = _method_container.SelectNodes(".//*[contains(@class, 'field-even')]");
                        if (_return_section == null) throw new ArgumentException("NO METHOD RETURN");

                        var _return_info_type = _return_section[1].SelectSingleNode(".//dt");
                        if (_return_info_type != null)
                        {
                            var return_name = _return_info_type.SelectSingleNode(".//strong")?.InnerText;
                            var return_type = _return_info_type.SelectSingleNode(".//span")?.InnerText;

                            if (return_name == null && return_type == null)
                            {
                                if (_return_info_type.InnerText.Contains("self"))
                                {
                                    PrintMethods(writer, _method_name, method_args, method_kw, method_types, class_name, self: true);
                                }
                                else throw new ArgumentException("UNKNOW RETURN");
                            }
                            else
                            {
                                if (return_name == "self")
                                {
                                    PrintMethods(writer, _method_name, method_args, method_kw, method_types, class_name, self: true);
                                }
                                else if (return_type != null)
                                {
                                    PrintMethods(writer, _method_name, method_args, method_kw, method_types, GeneratorMapper.FixParamType(return_type));
                                }
                                else
                                {
                                    throw new ArgumentException("UNKNOW RETURN WITH NAME");
                                }
                            }

                        }
                    }

                    writer.WriteLine("\t\t}");
                    genWriter.PrintClose(current_line);
                }
                else
                {
                    // No Methods
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }





    private static void PrintParamsList(
        IWriter writer,
        Dictionary<string, string?> param_args,
        Dictionary<string, string?> param_kw,
        Dictionary<string, string> param_types)
    {
        int total = param_args.Count + param_kw.Count;
        int i = 0;
        foreach (var item in param_args)
        {
            i++;
            if (param_types.TryGetValue(item.Key, out string type))
            {
                if (item.Value == null) writer.Write($"{type} {item.Key}");
                else writer.Write($"{type} {item.Key} = {item.Value}");
                if (i != total) writer.Write(", ");
            }
        }
        foreach (var item in param_kw)
        {
            i++;
            if (param_types.TryGetValue(item.Key, out string type))
            {
                if (item.Value == null) writer.Write($"{type} {item.Key}");
                else writer.Write($"{type} {item.Key} = {item.Value}");
                if (i != total) writer.Write(", ");
            }
        }
    }

    private static void PrintInvokableArguments(
        IWriter writer,
        Dictionary<string, string?> param_args,
        Dictionary<string, string?> param_kw,
        Dictionary<string, string> param_types)
    {
        if (param_args.Count > 0)
        {
            string args = string.Join(", ", param_args.Select(x => x.Key).ToArray());
            writer.WriteLine($"\t\t\t\tPyTuple args = ToTuple(new object[] {{{args}}});");
        }
        else
        {
            writer.WriteLine("\t\t\t\tPyTuple args = new();");
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


    private static void PrintConstructor(
        IWriter writer,
        string @class,
        string library,
        Dictionary<string, string?> ctor_args,
        Dictionary<string, string?> ctor_kw,
        Dictionary<string, string> ctor_param_types)
    {
        writer.Write($"\t\t\tpublic {@class}(");
        PrintParamsList(writer, ctor_args, ctor_kw, ctor_param_types);
        writer.WriteLine(")");

        writer.WriteLine("\t\t\t{");

        PrintInvokableArguments(writer, ctor_args, ctor_kw, ctor_param_types);
        writer.WriteLine($"\t\t\t\tself = {library}.self.InvokeMethod(\"{@class}\", args, pyDict);");


        writer.WriteLine("\t\t\t}");
        writer.WriteLine();
    }

    private static void PrintMethods(
        IWriter writer,
        string method_name,
        Dictionary<string, string?> method_args,
        Dictionary<string, string?> method_kw,
        Dictionary<string, string> method_types,
        string return_type,
        bool self = false)
    {
        writer.Write($"\t\t\tpublic {return_type} {method_name}(");
        PrintParamsList(writer, method_args, method_kw, method_types);
        writer.WriteLine(")");

        writer.WriteLine("\t\t\t{");
        PrintInvokableArguments(writer, method_args, method_kw, method_types);

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



    private static void PrintProperties(IWriter writer, Dictionary<string, string[]> dictionary)
    {
        foreach (var (key, types) in dictionary)
        {
            string propertyDefinition = types.Length switch
            {
                1 => types[0] == "PyObject"
                    ? $"\t\t\tpublic PyObject {key} => self.GetAttr(\"{key}\");"
                    : $"\t\t\tpublic {types[0]} {key} => ToCsharp<{types[0]}>(self.GetAttr(\"{key}\"));",

                2 when types.Contains("NDarray") && (types.Contains("bool") || types.Contains("int") || types.Contains("float"))
                    => $"\t\t\tpublic NDarray {key} => ToCsharp<NDarray>(self.GetAttr(\"{key}\"));",

                _ => throw new ArgumentException($"RETORNOS NO COMPATIBLES {string.Join(", ", types)}")
            };

            writer.WriteLine(propertyDefinition);
            writer.WriteLine();
        }
    }
}
