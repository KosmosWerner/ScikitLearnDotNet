using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeGenerator;

internal class GeneratorMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="default_param">True,False,None,"Ohter"</param>
    /// <returns></returns>
    public static string FixDefaultValue(string default_param)
    {
        string result = default_param switch
        {
            "True" => "true",
            "False" => "false",
            "None" => "null",
            _ => Regex.IsMatch(default_param, @"^\d+\.\d+$")
                ? $"{default_param}f"
                : default_param.Replace("'", "\"")
        };

        Debug.WriteLine($"CONVERT {default_param} -> {result}");
        return result;
    }

    private static string[] FixReturnType(string raw_type)
    {




        bool nullable = raw_type.Contains("None", StringComparison.OrdinalIgnoreCase) ||
                        raw_type.Contains("Ignored", StringComparison.OrdinalIgnoreCase);

        var typePatterns = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "True", "bool" },
            { "False", "bool" },
            { "bool", "bool" },
            { "int", "int" },
            { "float", "float" },
            { "str", "string" },
            { "{‘", "string" },
            { "{'", "string" },
            { "{\"", "string" },
            { "ndarray", "NDarray" },
            { "array", "NDarray" },
            { "shape", "NDarray" },
            { "sparce", "NDarray" },
            { "PyDict", "dict" }
        };

        var result = typePatterns
            .Where(kv => raw_type.Contains(kv.Key))
            .Select(kv => kv.Value)
            .Distinct()
            .ToList();

        if (nullable && result.Count > 1)
            throw new ArgumentException("RETORNO NULLABLE EN ATRIBUTO DE MULTIPLE TIPO");
        if (nullable && result.Count == 1) result[0] += "?";
        if (result.Count == 0) result.Add("PyObject");

        return result.ToArray();
    }

    public static string FixParamType(string raw_type, string default_value = "")
    {
        bool is_arg = string.IsNullOrEmpty(default_value);

        if (is_arg)
        {

        }
        else
        {

        }

        string clear_raw_type = Regex.Replace(raw_type, @"\(([^()]*)\)", m =>
        {
            return m.Value.Replace(",", ""); // Elimina las comas dentro de cada paréntesis
        });

        // Paso 2: Divide en base a comas o "or" fuera de los paréntesis
        var parts = Regex.Split(clear_raw_type, @"\s*,\s*|\s+or\s+");

        //Debug.WriteLine(string.Join(" ||||||| ", parts));



        if (raw_type.Contains("Ignored", StringComparison.OrdinalIgnoreCase)) return "PyObject?";

        bool nullable = raw_type.Contains("None", StringComparison.OrdinalIgnoreCase);

        bool multiple = raw_type.Contains(" or ", StringComparison.OrdinalIgnoreCase);

        var typePatterns = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "True", "bool" },
            { "False", "bool" },
            { "bool", "bool" },
            { "int", "int" },
            { "float", "float" },
            { "str", "string" },
            { "‘", "string" },
            { "“", "string" },
            { "{‘", "string" },
            { "{'", "string" },
            { "{\"", "string" },
            { "\"", "string" },
            { "ndarray", "NDarray" },
            { "array", "NDarray" },
            { "shape", "NDarray" },
            { "sparce", "NDarray" },
            { "PyDict", "dict" },

        };

        var result = typePatterns
            .Where(kv => raw_type.Contains(kv.Key))
            .Select(kv => kv.Value)
            .Distinct()
            .Reverse()
            .ToList();

        if (result.Count > 1)
            if (!multiple)
                result = [result[0]];


        if (result.Count > 1)
        {
            if (nullable)
            {
                if (default_value == null)
                    throw new ArgumentException("RETORNO NULLABLE EN ATRIBUTO DE MULTIPLE TIPO");
                else
                {
                    if (result.Contains("string"))
                        if (default_value.Contains("\"") || default_value.Contains("‘") || default_value.Contains("“") || default_value.Contains("'"))
                            return "string?";
                    if (result.Contains("float"))
                        if (float.TryParse(default_value, out _))
                            return "float?";
                    if (result.Contains("int"))
                        if (int.TryParse(default_value, out _))
                            return "int?";
                    if (result.Contains("bool"))
                        if (default_value == "true" || default_value == "false")
                            return "bool?";

                    //Console.WriteLine(string.Join(", ",result));
                    return result[^1] + "?";

                }
            }
            else
            {
                if (default_value == null)
                    throw new ArgumentException($"PARAMETRO MULTITIPLO SIN EJEMPLO {string.Join(",", result)}");
                else
                {
                    if (result.Contains("string"))
                        if (default_value.Contains("\"") || default_value.Contains("‘") || default_value.Contains("'"))
                            return "string";
                    if (result.Contains("float"))
                        if (float.TryParse(default_value, out _))
                            return "float";
                    if (result.Contains("int"))
                        if (int.TryParse(default_value, out _))
                            return "int";
                    if (result.Contains("bool"))
                        if (default_value == "true" || default_value == "false")
                            return "bool";
                    //Console.WriteLine(string.Join(", ", result));

                    return result[^1];
                }

            }
        }
        if (result.Count == 1)
            if (nullable) result[0] += "?";
        if (result.Count == 0) result.Add("PyObject");

        return result[0];
    }



    public static class Attributes
    {
        public static void AssignTypes(Dictionary<string, string[]> properties, string? name, string? type)
        {
            if (name == null || type == null) return;

            properties[name] = FixReturnType(type);
        }
    }

    public static class MethodParams
    {
        public static void AssignDefaultValues(
            string? param_operator,
            string? param_name,
            string? param_default,
            ref bool is_arg,
            Dictionary<string, string> method_args,
            Dictionary<string, string> method_kw)
        {
            if (param_operator == "*")
            {
                is_arg = false;
                return;
            }

            if (param_name == null) return;

            if (param_operator == "**")
            {
                method_kw["@params"] = FixDefaultValue("None"); ;
                return;
            }

            var current = is_arg && param_default == null ? method_args : method_kw;

            current[param_name] = param_default != null ? FixDefaultValue(param_default) : string.Empty;
        }

        public static void AssignTypes(
            string? param_name,
            string? param_type,
            Dictionary<string, string> param_args,
            Dictionary<string, string> param_kw,
            Dictionary<string, string> param_types)
        {
            if (param_name == null || param_type == null) return;

            if (param_name.StartsWith("**"))
            {
                param_types["@params"] = "PyDict?";
                return;
            }

            string default_param = string.Empty;

            if (param_args.TryGetValue(param_name, out string? value_arg))
            {
                default_param = value_arg;
            }
            else if (param_kw.TryGetValue(param_name, out string? value_kw))
            {
                default_param = value_kw;
            }
            else return;

            param_types[param_name] = FixParamType(param_type, default_param);
        }
    }
}
