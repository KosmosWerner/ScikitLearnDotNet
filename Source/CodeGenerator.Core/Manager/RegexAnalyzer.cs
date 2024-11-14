using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeGenerator.Core.Manager
{
    public static partial class RegexAnalyzer
    {
        public static (string identifier, string fullName, string fullParameters) Declaration(string declaration)
        {
            Match declarationMatch = RegexDeclaration().Match(declaration);
            return (declarationMatch.Groups[1].Value,
                declarationMatch.Groups[2].Value,
                declarationMatch.Groups[3].Value);
        }

        public static List<string> Parameters(string parameters)
        {
            return [];///////////////////////
        }

        [GeneratedRegex(@"(\w+\s+)?([\w\.]+)(\((.*)\))?")]
        private static partial Regex RegexDeclaration();
    }
}
