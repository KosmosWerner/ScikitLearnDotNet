﻿using CodeGenerator.Utils;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CodeGenerator;

internal static partial class Generator
{
    public static async Task GenerateFrom(Dictionary<string, List<Uri>> source)
    {
        foreach (var (current_namespace, urls) in source)
        {
            await GenerateFromNamespace(current_namespace, urls);
        }
    }

    public static async Task GenerateFromNamespace(string current_namespace, List<Uri> urls)
    {
        string path = Path.Combine(Path.GetFullPath("."), "src", $"{current_namespace}.cs");

        GeneratorWriter generatorWriter = new(new ConsoleWriter(), current_namespace, urls.Count);

        generatorWriter.PrintStartStaticClass();

        foreach (var url in urls)
        {
            using HttpClient client = new();

            try
            {
                #region PreparePageContent

                string pageContent = await client.GetStringAsync(url);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(pageContent);

                var nodeContent = htmlDoc.DocumentNode.SelectSingleNode("//*[contains(@class, 'bd-article')]");
                ArgumentNullException.ThrowIfNull(nodeContent);

                #endregion

                var nodeDeclaration = nodeContent.SelectSingleNode(".//*[contains(@class, 'sig sig-object py')]");
                if (nodeDeclaration == null)
                {
                    // sklearn.experimental
                    // https://scikit-learn.org/stable/modules/generated/sklearn.experimental.enable_halving_search_cv.html
                    // https://scikit-learn.org/stable/modules/generated/sklearn.experimental.enable_iterative_imputer.html
                    continue;
                }

                Match declarationMatch = Regex.Match(nodeDeclaration.InnerText, @"(\w+\s+)?([\w\.]+)(\((.*)\))?");

                Trace.WriteLine(nodeDeclaration.InnerText);
                Trace.WriteLine(declarationMatch.Groups[1].Success);
                Trace.WriteLine(declarationMatch.Groups[2].Value);
                Trace.WriteLine(declarationMatch.Groups[3].Value);
                if (declarationMatch.Groups[1].Value.Contains("exception"))
                {
                    Trace.WriteLine("EXCEPTION");
                }
                else if (char.IsLower(declarationMatch.Groups[2].Value.Split('.')[^1][0]))
                {
                    Trace.WriteLine("METHOD");
                }
                else if (char.IsUpper(declarationMatch.Groups[2].Value.Split('.')[^1][0]))
                {
                    Trace.WriteLine("CLASS");
                }
                else
                {
                    Trace.WriteLine("UNKNOWWWWWW");
                }


                var nodeIdentifier = nodeContent.SelectSingleNode(".//*[contains(@class, 'property')]");
                if (nodeIdentifier == null)
                {
                    GenerateMethod(generatorWriter, nodeContent, nodeDeclaration);
                }
                else
                {
                    // check false positive
                    var nodeParamsAndAttributes = nodeContent.SelectSingleNode(".//*[contains(@class, 'field-list') and not(ancestor::*/ancestor::*[contains(@class, 'py method')])]");
                    var _attributes_section = nodeParamsAndAttributes?.SelectNodes(".//*[contains(@class, 'field-even')]");


                    if (_attributes_section?[0]?.InnerText?.Contains("Return") ?? false) // Unusual, but exists
                    {
                        // https://scikit-learn.org/stable/modules/generated/sklearn.compose.make_column_selector.html
                        // https://scikit-learn.org/stable/modules/generated/sklearn.compose.make_column_transformer.html
                        GenerateMethod(generatorWriter, nodeContent, nodeDeclaration);
                    }
                    else
                    {
                        GenerateClass(generatorWriter, nodeContent, nodeDeclaration);
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }

        generatorWriter.PrintEndStaticClass();
    }

    private static void GenerateMethod(GeneratorWriter generatorWriter, HtmlNode nodeContent, HtmlNode nodeDescription)
    {
        Trace.WriteLine("->Method");
        var methodName = nodeDescription.SelectSingleNode(".//*[contains(@class, 'sig-name descname')]")?.InnerText;
        ArgumentNullException.ThrowIfNull(methodName);


    }

    private static void GenerateClass(GeneratorWriter generatorWriter, HtmlNode nodeContent, HtmlNode nodeDescription)
    {
        Trace.WriteLine("->Class");
        var className = nodeDescription.SelectSingleNode(".//*[contains(@class, 'sig-name descname')]")?.InnerText;
        ArgumentNullException.ThrowIfNull(className);

        var nodeParamsAndAttributes = nodeContent.SelectSingleNode(".//*[contains(@class, 'field-list') and not(ancestor::*/ancestor::*[contains(@class, 'py method')])]");
        var nodeMethodCollection = nodeContent.SelectNodes(".//*[contains(@class, 'py method')]");

        generatorWriter.PrintStartClass(className);

        #region Constructor

        #region DefaultParams
        Dictionary<string, string> ctor_args = [];
        Dictionary<string, string> ctor_kw = [];
        Dictionary<string, string> ctor_types = [];
        bool ctor_is_arg = true;

        var nodeCtorParams = nodeDescription.SelectNodes(".//*[contains(@class, 'sig-param')]");
        if (nodeCtorParams != null)
        {
            foreach (var nodeParam in nodeCtorParams)
            {
                GeneratorMapper.MethodParams
                    .AssignDefaultValues(nodeParam.InnerText, ref ctor_is_arg, ctor_args, ctor_kw);
            }
        }
        #endregion

        #region MatchParamsTypes
        if (nodeParamsAndAttributes == null)
        {
            generatorWriter.PrintConstructor(className, ctor_args, ctor_kw, ctor_types);
        }
        else
        {
            var nodeTypesSection = nodeParamsAndAttributes.SelectNodes(".//*[contains(@class, 'field-odd')]");
            if (nodeTypesSection != null)
            {
                // Check Header
                if (nodeTypesSection[0].InnerText.Contains("Parameter"))
                {
                    // Iterate Content
                    var _param_types = nodeTypesSection[1].SelectNodes(".//dt");
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

                    generatorWriter.PrintConstructor(className, ctor_args, ctor_kw, ctor_types);
                }
                else
                {
                    throw new ArgumentException($"Constructor: field-odd isn't Parameters: {nodeTypesSection[0].InnerText}\");");
                }
            }
        }
        #endregion

        #endregion

        #region Attributes
        if (nodeParamsAndAttributes != null)
        {
            var _attributes_section = nodeParamsAndAttributes.SelectNodes(".//*[contains(@class, 'field-even')]");
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

                            GeneratorMapper.Attributes
                                .AssignTypes(class_attributes, property_name, property_type);
                        }
                    }

                    generatorWriter.PrintAttributes(class_attributes);
                }
                else
                {
                    throw new ArgumentException($"Class: field-even isn't Attribute: {_attributes_section[0].InnerText}\");");
                }
            }
        }
        #endregion

        #region Methods
        if (nodeMethodCollection != null)
        {
            foreach (var _method_container in nodeMethodCollection)
            {
                var _declaration = _method_container.SelectSingleNode(".//*[contains(@class, 'sig sig-object py')]") ??
                    throw new ArgumentException("Documentation: Method without declaration");

                var method_name = (_declaration.SelectSingleNode(".//*[contains(@class, 'sig-name descname')]")?.InnerText) ??
                    throw new ArgumentException("Documentation: Method without name");

                if (method_name.Contains("__")) throw new Exception("fsdafsadfasdfsadfasdfasdf");

                #region DefaultParams
                Dictionary<string, string> method_args = [];
                Dictionary<string, string> method_kw = [];
                Dictionary<string, string> method_types = [];
                bool method_is_arg = true;

                var _method_params = _declaration.SelectNodes(".//*[contains(@class, 'sig-param')]");
                if (_method_params != null)
                {
                    foreach (var _param in _method_params)
                    {
                        GeneratorMapper.MethodParams
                            .AssignDefaultValues(_param.InnerText, ref method_is_arg, method_args, method_kw);
                    }
                }
                #endregion

                //// Args Types ////
                var _odd_section = _method_container.SelectNodes(".//*[contains(@class, 'field-odd')]");
                var _even_section = _method_container.SelectNodes(".//*[contains(@class, 'field-even')]");

                if (_odd_section == null && _even_section == null)
                {
                    continue;  // Method with NotImplementedException
                }

                #region OnlyReturn
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
                #endregion

                #region MatchParamsTypes
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
                #endregion



                //// Return Type ////
                if (_return_section == null)
                    throw new ArgumentException("Method has no return type section.");

                var _return_info_type = _return_section[1].SelectSingleNode(".//dt");
                if (_return_info_type != null)
                {
                    var return_name = _return_info_type.SelectSingleNode(".//strong")?.InnerText;
                    var return_type = _return_info_type.SelectSingleNode(".//span")?.InnerText;

                    if (return_name == null && return_type == null)
                    {
                        // only _return_info_type.InnerText

                        if (_return_info_type.InnerText.Contains("self"))
                        {
                            generatorWriter.PrintMethods(method_name, method_args, method_kw, method_types, className, self: true);
                        }
                        else if (_return_info_type.InnerText.Contains('_'))
                        {
                            generatorWriter.PrintMethods(method_name, method_args, method_kw, method_types, GeneratorMapper.FixParamType(_return_info_type.InnerText));
                        }
                        else
                            throw new ArgumentException($"Unknown return type: {_return_info_type.InnerText}");
                    }
                    else
                    {
                        if (return_name == "self")
                        {
                            generatorWriter.PrintMethods(method_name, method_args, method_kw, method_types, className, self: true);
                        }
                        else if (return_type != null)
                        {
                            generatorWriter.PrintMethods(method_name, method_args, method_kw, method_types, GeneratorMapper.FixParamType(return_type));
                        }
                        else
                        {
                            throw new ArgumentException("Unknown return type with name.");
                        }
                    }

                }
            }
        }
        #endregion

        generatorWriter.PrintEndClass();
    }
}
