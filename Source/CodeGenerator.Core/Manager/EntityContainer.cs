using HtmlAgilityPack;

namespace CodeGenerator.Core.Manager
{
    public class EntityContainer
    {
        public HtmlNode? ContentNode { get; }
        public string? Declaration { get; }
        public HtmlNode? ParamsBox { get; }
        public HtmlNode? ReturnsBox { get; }
        public HtmlNode? AttributesBox { get; }
        public HtmlNodeCollection? MethodsBoxes { get; }


        public EntityContainer(string pageContent)
        {
            var document = new HtmlDocument();
            document.LoadHtml(pageContent);

            ContentNode = document.DocumentNode.SelectSingleNode("//*[contains(@class, 'bd-article')]");
            Declaration = ContentNode?.SelectSingleNode(".//*[contains(@class, 'sig sig-object py')]")?.InnerText;


            var fieldList = ContentNode?.SelectSingleNode(".//*[contains(@class, 'field-list') and not(ancestor::*/ancestor::*[contains(@class, 'py method')]) and not(ancestor::*/ancestor::*[contains(@class, 'py property')])]");
            if (fieldList != null)
            {
                var evenList = fieldList?.SelectNodes(".//*[contains(@class, 'field-even')]");
                var oddList = fieldList?.SelectNodes(".//*[contains(@class, 'field-odd')]");

                if (evenList != null)
                {
                    string header = evenList[0].InnerText;
                    if (header.Contains("Return") || header.Contains("Yield")) ReturnsBox = evenList[1];
                    else if (header.Contains("Attribute")) AttributesBox = evenList[1];
                    else if (header.Contains("Parameter")) ParamsBox = evenList[1];
                }

                if (oddList != null)
                {
                    string header = oddList[0].InnerText;
                    if (header.Contains("Return") || header.Contains("Yield")) ReturnsBox = oddList[1];
                    else if (header.Contains("Attribute")) AttributesBox = oddList[1];
                    else if (header.Contains("Parameter")) ParamsBox = oddList[1];
                }
            }

            MethodsBoxes = ContentNode?.SelectNodes(".//*[contains(@class, 'py method')]");
        }

        public EntityContainer(HtmlNode content)
        {
            ContentNode = content;

            Declaration = ContentNode?.SelectSingleNode(".//*[contains(@class, 'sig sig-object py')]")?.InnerText;

            var fieldList = ContentNode?.SelectSingleNode(".//*[contains(@class, 'field-list')]");
            if (fieldList != null)
            {
                var evenList = fieldList?.SelectNodes(".//*[contains(@class, 'field-even')]");
                var oddList = fieldList?.SelectNodes(".//*[contains(@class, 'field-odd')]");

                if (evenList != null)
                {
                    string header = evenList[0].InnerText;
                    if (header.Contains("Return") || header.Contains("Yield")) ReturnsBox = evenList[1];
                    else if (header.Contains("Parameter")) ParamsBox = evenList[1];
                }

                if (oddList != null)
                {
                    string header = oddList[0].InnerText;
                    if (header.Contains("Return") || header.Contains("Yield")) ReturnsBox = oddList[1];
                    else if (header.Contains("Parameter")) ParamsBox = oddList[1];
                }
            }
        }
    }
}
