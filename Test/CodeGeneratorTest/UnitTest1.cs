using CodeGenerator.Core;
using CodeGenerator.Core.Manager;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CodeGeneratorTest
{
    public class UnitTest1
    {
        private readonly Lazy<Task<Dictionary<string, List<Uri>>>> _lazyUrls;

        public UnitTest1()
        {
            _lazyUrls = new(() => UriSearcher.Search("https://scikit-learn.org/stable/api/sklearn.html"));
        }

        [Fact]
        public async Task NameClassification()
        {
            var source = await _lazyUrls.Value;

            foreach (var (current_namespace, urls) in source)
            {
                foreach (var url in urls)
                {
                    using HttpClient client = new();

                    try
                    {
                        string pageContent = await client.GetStringAsync(url);

                        EntityContainer page = new(pageContent);
                        ArgumentNullException.ThrowIfNull(page.ContentNode);

                        var declaration = page.Declaration;
                        if (declaration == null)
                        {
                            // sklearn.experimental
                            // https://scikit-learn.org/stable/modules/generated/sklearn.experimental.enable_halving_search_cv.html
                            // https://scikit-learn.org/stable/modules/generated/sklearn.experimental.enable_iterative_imputer.html
                            continue;
                        }

                        Match declarationMatch = Regex.Match(declaration, @"(\w+\s+)?([\w\.]+)(\((.*)\))?");
                        string identifier = declarationMatch.Groups[1].Value;
                        string name = declarationMatch.Groups[2].Value.Split('.')[^1];
                        string rawParameters = declarationMatch.Groups[3].Value;

                        #region ShortMethod

                        string expectedValue = string.Empty;

                        if (identifier.Contains("exception")) expectedValue = "exception";
                        else
                        {
                            if (identifier.Contains("class"))
                            {
                                if (page.ReturnsBox != null) expectedValue = "method"; // las clases no retornan en C#
                                else expectedValue = "class"; // existen funciones que no retornan nada

                            }
                            else expectedValue = "method";
                        }
                        #endregion


                        // slow method
                        string obtainedValue = string.Empty;

                        var nodeIdentifier = page.ContentNode.SelectSingleNode(".//*[contains(@class, 'property')]");
                        if (nodeIdentifier == null)
                        {
                            obtainedValue = "method";
                        }
                        else
                        {
                            // check false positive
                            var nodeParamsAndAttributes = page.ContentNode.SelectSingleNode(".//*[contains(@class, 'field-list') and not(ancestor::*/ancestor::*[contains(@class, 'py method')]) and not(ancestor::*/ancestor::*[contains(@class, 'py property')])]");
                            var _attributes_section = nodeParamsAndAttributes?.SelectNodes(".//*[contains(@class, 'field-even')]");

                            if (_attributes_section?[0]?.InnerText?.Contains("Return") ?? false) // Unusual, but exists
                            {
                                // https://scikit-learn.org/stable/modules/generated/sklearn.compose.make_column_selector.html
                                // https://scikit-learn.org/stable/modules/generated/sklearn.compose.make_column_transformer.html
                                obtainedValue = "method";
                            }
                            else
                            {
                                if (declarationMatch.Groups[1].Value.Contains("exception"))
                                    obtainedValue = "exception";
                                else
                                    obtainedValue = "class";
                            }
                        }



                        Console.WriteLine($"{expectedValue} - {obtainedValue:-15}\tReturn: {page.ReturnsBox != null:-8}\tParams: {page.ParamsBox != null:-8}\tAttributes: {page.AttributesBox != null:-8} {page.Declaration}");
                        Assert.Equal(expectedValue, obtainedValue);

                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }

                }
            }
        }
    }
}