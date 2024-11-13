using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeGenerator;

internal static class UriSearcher
{
    private static readonly string URL_LIST = "current nav bd-sidenav";
    private static readonly string URL_LIST_ITEM = "reference internal";
    private static readonly string DEPRECATED = "deprecated";

    public static async Task<Dictionary<string, List<Uri>>> Search(string url)
    {
        using var client = new HttpClient();
        var baseUri = new Uri(url);

        try
        {
            string pageContent = await client.GetStringAsync(baseUri);
            var doc = new HtmlDocument();
            doc.LoadHtml(pageContent);

            var tabs = doc.DocumentNode.SelectSingleNode($"//*[contains(@class, '{URL_LIST}')]");
            if (tabs == null) return [];

            var internallink = tabs.SelectNodes($"//*[contains(@class, '{URL_LIST_ITEM}')]");
            if (internallink == null) return [];

            List<Uri> uris = [];
            foreach (var tab in internallink)
            {
                string href = tab.GetAttributeValue("href", string.Empty);

                if (href == "#") uris.Add(baseUri);
                else uris.Add(new Uri(baseUri, href));
            }
            
            return Search(uris);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        return [];
    }

    private static Dictionary<string, List<Uri>> Search(List<Uri> uris)
    {
        string namespacePattern = @"https:\/\/scikit-learn\.org\/stable\/api\/([A-Za-z0-9_-]+(?:\.[A-Za-z0-9_-]+)?)\.html";
        string lastNamespace = string.Empty;

        Dictionary<string, List<Uri>> result = [];

        foreach (Uri item in uris)
        {
            Match match = Regex.Match(item.ToString(), namespacePattern);
            if (match.Success)
            {
                lastNamespace = match.Groups[1].Value;

                if (lastNamespace == DEPRECATED) continue;

                if (!result.ContainsKey(lastNamespace)) result[lastNamespace] = [];
            }
            else
            {
                if (lastNamespace == DEPRECATED) continue;

                result[lastNamespace].Add(item);
            }
        }
        return result;
    }
}
