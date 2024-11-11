using CodeGenerator.Utils;
using HtmlAgilityPack;
using System.Reflection.Metadata.Ecma335;

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

    public static async Task GenerateFromNamespace(string current_namespace, List<Uri> urls)
    {
        string folderName = "src";
        string fileName = current_namespace + ".cs";
        string path = Path.Combine(Path.GetFullPath("."), folderName, fileName);

        //IWriter writer = new ToFileWriter(path);
        GeneratorWriter generatorWriter = new(new ToFileWriter(path), current_namespace, urls.Count);

        int current_line = 0;

        generatorWriter.PrintStartStaticClass();
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
                    generatorWriter.PrintEndStaticClass();
                    return;
                }

                /////////////////////////////
                //// General Description ////
                /////////////////////////////

                var _use_description = _container.SelectSingleNode(".//*[contains(@class, 'sig sig-object py')]")
                    ?? throw new ArgumentNullException("No class description");

                //// Is Class ////
                var is_class = _container.SelectSingleNode(".//*[contains(@class, 'property')]");
                if (is_class == null)
                {
                    continue;
                }

                //// Class Name ////
                var class_name = _use_description.SelectSingleNode(".//*[contains(@class, 'sig-name descname')]")?.InnerText
                    ?? throw new ArgumentNullException("No class name");

                generatorWriter.PrintStartClass(class_name);

                ///////////////////////
                ////  Constructor  ////
                ///////////////////////

                Dictionary<string, string> ctor_args = [];
                Dictionary<string, string> ctor_kw = [];
                Dictionary<string, string> ctor_types = [];
                bool ctor_is_arg = true;

                //// Default Args ////
                var _ctor_params = _use_description.SelectNodes(".//*[contains(@class, 'sig-param')]");
                if (_ctor_params != null)
                {
                    // Exists constructor params: default value
                    foreach (var _param in _ctor_params)
                    {
                        GeneratorMapper.MethodParams.AssignDefaultValues(
                            _param.InnerText,
                            ref ctor_is_arg,
                            ctor_args,
                            ctor_kw);
                    }
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
                        // Check Header
                        if (_ctor_types_section[0].InnerText.Contains("Parameter"))
                        {
                            // Iterate Content
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

                            generatorWriter.PrintConstructor(class_name, ctor_args, ctor_kw, ctor_types);
                        }
                        else
                        {
                            throw new ArgumentException($"Constructor: field-odd isn't Parameters: {_ctor_types_section[0].InnerText}\");");
                        }
                    }

                    //////////////////////
                    ////  Attributes  ////
                    //////////////////////

                    var _attributes_section = _ctor_types_and_fields.SelectNodes(".//*[contains(@class, 'field-even')]");
                    if (_attributes_section != null)
                    {
                        Dictionary<string, string[]> class_attributes = [];
                        // Check Header
                        if (_attributes_section[0].InnerText.Contains("Attribute"))
                        {
                            // Iterate Content
                            var _attribute = _attributes_section[1].SelectNodes(".//dt");
                            if (_attribute != null)
                            {
                                foreach (var _property in _attribute)
                                {
                                    var property_name = _property.SelectSingleNode(".//strong")?.InnerText;
                                    var property_type = _property.SelectSingleNode(".//span")?.InnerText;

                                    GeneratorMapper.Attributes.AssignTypes(
                                        class_attributes,
                                        property_name,
                                        property_type);
                                }
                            }

                            generatorWriter.PrintAttributes(class_attributes);
                        }
                        else
                        {
                            continue; ////// CHECK THIS
                            throw new ArgumentException($"Class: field-even isn't Attributes: {_attributes_section[0].InnerText}\");");
                        }
                    }
                }
                else
                {
                    // No exists constructor params types and class fields
                    generatorWriter.PrintConstructor(class_name, ctor_args, ctor_kw, ctor_types);
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
                        var _declaration = _method_container.SelectSingleNode(".//*[contains(@class, 'sig sig-object py')]") ??
                            throw new ArgumentException("Documentation: Method without declaration");

                        var method_name = (_declaration.SelectSingleNode(".//*[contains(@class, 'sig-name descname')]")?.InnerText) ??
                            throw new ArgumentException("Documentation: Method without name");

                        if (method_name.Contains("__")) continue; ///// Internal callable

                        //// Default Args ////
                        Dictionary<string, string> method_args = [];
                        Dictionary<string, string> method_kw = [];
                        Dictionary<string, string> method_types = [];
                        bool method_is_arg = true;

                        var _method_params = _declaration.SelectNodes(".//*[contains(@class, 'sig-param')]");

                        if (_method_params != null)
                        {
                            foreach (var _param in _method_params)
                            {
                                GeneratorMapper.MethodParams.AssignDefaultValues(
                                    _param.InnerText,
                                    ref method_is_arg,
                                    method_args,
                                    method_kw);
                            }
                        }

                        //// Args Types ////
                        var _odd_section = _method_container.SelectNodes(".//*[contains(@class, 'field-odd')]");
                        var _even_section = _method_container.SelectNodes(".//*[contains(@class, 'field-even')]");

                        if (_odd_section == null && _even_section == null)
                        {
                            continue; // Not implemented exception
                            // throw new ArgumentException("Method: no params, no return");
                        }

                        HtmlNodeCollection? _params_section = null;
                        HtmlNodeCollection? _return_section = null;

                        if (_odd_section != null && _even_section == null)
                        {
                            if (_odd_section[0].InnerText.Contains("Return"))
                                _return_section = _odd_section;
                            else throw new ArgumentException("Method: no return");
                        }
                        else
                        {
                            _params_section = _odd_section;
                            _return_section = _even_section;
                        }

                        if (_params_section != null)
                        {
                            if (!_params_section[0].InnerText.Contains("Parameter"))
                                throw new ArgumentException($"Method field-odd isn't Parameters: {_params_section[0].InnerText}");

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
                        if (_return_section == null)
                            throw new ArgumentException("NO METHOD RETURN");

                        var _return_info_type = _return_section[1].SelectSingleNode(".//dt");
                        if (_return_info_type != null)
                        {
                            var return_name = _return_info_type.SelectSingleNode(".//strong")?.InnerText;
                            var return_type = _return_info_type.SelectSingleNode(".//span")?.InnerText;

                            if (return_name == null && return_type == null)
                            {
                                if (_return_info_type.InnerText.Contains("self"))
                                {
                                    generatorWriter.PrintMethods(method_name, method_args, method_kw, method_types, class_name, self: true);
                                }
                                else if(_return_info_type.InnerText.Contains('_'))
                                {
                                    generatorWriter.PrintMethods(method_name, method_args, method_kw, method_types, GeneratorMapper.FixParamType(_return_info_type.InnerText));
                                }
                                else throw new ArgumentException("UNKNOW RETURN");
                            }
                            else
                            {
                                if (return_name == "self")
                                {
                                    generatorWriter.PrintMethods(method_name, method_args, method_kw, method_types, class_name, self: true);
                                }
                                else if (return_type != null)
                                {
                                    generatorWriter.PrintMethods(method_name, method_args, method_kw, method_types, GeneratorMapper.FixParamType(return_type));
                                }
                                else
                                {
                                    throw new ArgumentException("UNKNOW RETURN WITH NAME");
                                }
                            }

                        }
                    }

                }

                generatorWriter.PrintEndClass();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }
        generatorWriter.PrintEndStaticClass();
    }
}
