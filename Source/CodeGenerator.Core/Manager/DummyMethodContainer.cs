using HtmlAgilityPack;
using System.Text;
using System.Text.RegularExpressions;


namespace CodeGenerator.Core.Manager
{
    public class DummyMethodContainer
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

        public DummyMethodContainer() { }

        public DummyMethodContainer(HtmlContainer htmlContainer)
        {
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
        }

        public string Declaration { get; set; } = string.Empty;
        public List<string> Parameters { get; set; } = [];
        public List<string> Returns { get; set; } = [];
    }
}