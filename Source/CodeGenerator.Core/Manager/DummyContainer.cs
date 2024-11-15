using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeGenerator.Core.Manager
{
    public class DummyContainer
    {
        public static string FixFormat(string toFix)
        {
            var sb = new StringBuilder(toFix);

            sb.Replace("\n", "")
              .Replace("\u201C", "\"")
              .Replace("\u201D", "\"")
              .Replace("\u0027", "\"")
              .Replace("\u2018", "\"")
              .Replace("\u2019", "\"")
              .Replace("\u0026lt;", "<")
              .Replace("\u0026gt;", ">")
              .Replace("\u0026quot;", "\"");

            string result = sb.ToString();
            result = Regex.Replace(result, @"\s+", " "); 

            return result;
        }

        public DummyContainer() { }

        public DummyContainer(HtmlContainer htmlContainer)
        {
            EntityType = Classifier.ClassifyHtml(htmlContainer);

            Declaration = htmlContainer.Declaration ?? string.Empty;
            Declaration = FixFormat(Declaration); // Fix json Format

            var parameters = htmlContainer.ParamsBox?.SelectNodes(".//dt");
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    var strong = p.SelectSingleNode(".//strong")?.InnerText;
                    var span = p.SelectSingleNode(".//span")?.InnerText;

                    if (strong == null && span == null) Parameters.Add(FixFormat(p.InnerText));
                    else Parameters.Add(FixFormat($"{strong}:{span}"));
                }
            }

            var returns = htmlContainer.ReturnsBox?.SelectNodes(".//dt");
            if (returns != null)
            {
                foreach (var r in returns)
                {
                    var strong = r.SelectSingleNode(".//strong")?.InnerText;
                    var span = r.SelectSingleNode(".//span")?.InnerText;

                    if (strong == null && span == null) Returns.Add(FixFormat(r.InnerText));
                    else Returns.Add(FixFormat($"{strong}:{span}"));
                }
            }

            var attributes = htmlContainer.AttributesBox?.SelectNodes(".//dt");
            if (attributes != null)
            {
                foreach (var a in attributes)
                {
                    var strong = a.SelectSingleNode(".//strong")?.InnerText;
                    var span = a.SelectSingleNode(".//span")?.InnerText;

                    if (strong == null && span == null) Attributes.Add(FixFormat(a.InnerText));
                    else Attributes.Add(FixFormat($"{strong}:{span}"));
                }
            }

            if (htmlContainer.MethodsBoxes != null)
            {
                foreach (var box in htmlContainer.MethodsBoxes)
                {
                    var methodContainer = new HtmlContainer(box);
                    Methods.Add(new DummyMethodContainer(methodContainer));
                }
            }
        }

        public EntityType EntityType { get; set; } = EntityType.None;
        public string Declaration { get; set; } = string.Empty;
        public List<string> Parameters { get; set; } = [];
        public List<string> Returns { get; set; } = [];
        public List<string> Attributes { get; set; } = [];
        public List<DummyMethodContainer> Methods { get; set; } = [];
    }
}
