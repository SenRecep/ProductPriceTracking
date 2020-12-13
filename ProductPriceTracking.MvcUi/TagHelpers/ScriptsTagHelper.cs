using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ProductPriceTracking.MvcUi.TagHelpers
{
    public class ScriptsTagHelper : TagHelper
    {
        private static readonly object Itemskey = new object();

        private IDictionary<object, object> Items => _httpContextAccessor?.HttpContext?.Items;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ScriptsTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            context.AllAttributes.TryGetAttribute("render", out TagHelperAttribute attribute);

            bool render = false;

            if (attribute != null)
            {
                render = Convert.ToBoolean(attribute.Value.ToString());
            }

            if (render && Items.ContainsKey(Itemskey))
            {
                List<HtmlString> scripts = (List<HtmlString>)Items[Itemskey];
                string outputContent = string.Concat(scripts);
                output.Content.SetHtmlContent(outputContent);
            }
            else
            {
                List<HtmlString> list;

                if (!Items.ContainsKey(Itemskey))
                {
                    list = new List<HtmlString>();
                    Items[Itemskey] = list;
                }

                list = (List<HtmlString>)Items[Itemskey];

                TagHelperContent outputContent = await output.GetChildContentAsync();
                list.Add(new HtmlString(outputContent.GetContent()));
                output.Content.Clear();
            }
        }
    }
}
