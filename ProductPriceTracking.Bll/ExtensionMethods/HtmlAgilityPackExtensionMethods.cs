using System;
using System.Collections.Generic;
using System.Text;

using HtmlAgilityPack;

namespace ProductPriceTracking.Bll.ExtensionMethods
{
    public static class HtmlAgilityPackExtensionMethods
    {
        public static string GetInnerTextByXPath(this HtmlDocument document , string xpath)
        {
            return GetInnerTextByXPath(document.DocumentNode,xpath);
        }
        public static string GetInnerHtmlByXPath(this HtmlDocument document, string xpath)
        {
            return GetInnerHtmlByXPath(document.DocumentNode,xpath);
        }
        public static string GetInnerTextByXPath(this HtmlNode node, string xpath)
        {
            return node.SelectSingleNode(xpath)?.InnerText;
        }
        public static string GetInnerHtmlByXPath(this HtmlNode node, string xpath)
        {
            return node.SelectSingleNode(xpath)?.InnerHtml;
        }
    }
}
