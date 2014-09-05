using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BFound.HtmlToMarkdown
{
    public static class MarkDownDocument
    {
        public static string FromHtml(string html)
        {
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);
            var body = htmlDocument.DocumentNode.SelectSingleNode("//body");

            var mardownDocumentNode = new MarkDownNode();
            HtmlNodeToMarkDownNode(body ?? htmlDocument.DocumentNode, mardownDocumentNode);

            return mardownDocumentNode.ToString();
        }

        private static void HtmlNodeToMarkDownNode(HtmlAgilityPack.HtmlNode htmlNode, MarkDownNode markdownNode)
        {
            switch (htmlNode.Name.ToLowerInvariant())
            {
                case "p":
                    markdownNode = markdownNode.Append(new ParagraphMarkDownNode());
                    break;
                case "b":
                case "strong":
                    markdownNode = markdownNode.Append(new BoldMarkDownNode());
                    break;
                case "i":
                case "em":
                    markdownNode = markdownNode.Append(new ItalicMarkDownNode());
                    break;
                case "a":
                    markdownNode = markdownNode.Append(new LinkMarkDownNode
                    {
                        Href = AttrValue(htmlNode, "href")
                    });
                    break;
                case "img":
                    markdownNode = markdownNode.Append(new ImageMarkDownNode
                    {
                        Alt = AttrValue(htmlNode, "alt"),
                        Src = AttrValue(htmlNode, "src")
                    });
                    break;
                case "div":
                    markdownNode = markdownNode.Append(new DivMarkDownNode());
                    break;
                case "br":
                case "tr":
                    markdownNode = markdownNode.Append(new BreakMarkDownNode());
                    break;
                case "hr":
                    markdownNode = markdownNode.Append(new HorizontalRuleMarkDownNode());
                    break;
                case "h1":
                    markdownNode = markdownNode.Append(new HeadingMarkDownNode(1));
                    break;
                case "h2":
                    markdownNode = markdownNode.Append(new HeadingMarkDownNode(2));
                    break;
                case "h3":
                    markdownNode = markdownNode.Append(new HeadingMarkDownNode(3));
                    break;
                case "h4":
                    markdownNode = markdownNode.Append(new HeadingMarkDownNode(4));
                    break;
                case "h5":
                    markdownNode = markdownNode.Append(new HeadingMarkDownNode(5));
                    break;
                case "blockquote":
                    markdownNode = markdownNode.Append(new BlockquoteMarkDownNode());
                    break;
                case "ul":
                    markdownNode = markdownNode.Append(new UnorderdListMarkDownNode());
                    break;
                case "ol":
                    markdownNode = markdownNode.Append(new OrderdListMarkDownNode());
                    break;
                case "li":
                    markdownNode = markdownNode.Append(new ListItemMarkDownNode());
                    break;
                case "style":
                case "script":
                    markdownNode = markdownNode.Append(new EmptyMarkdownNode());
                    break;
                case "#text":
                    var text = System.Text.RegularExpressions.Regex.Replace(htmlNode.InnerText, "\\s+", " ");
                    markdownNode.Append(new TextMarkDownNode { Text = WebUtility.HtmlDecode(text) });
                    break;
            }
            foreach (var childNode in htmlNode.ChildNodes)
            {
                HtmlNodeToMarkDownNode(childNode, markdownNode);
            }
        }

        private static string AttrValue(HtmlAgilityPack.HtmlNode htmlNode, string name)
        {
            var attr = htmlNode.Attributes[name];
            return attr != null
                ? attr.Value
                : null;
        }
    }
}
