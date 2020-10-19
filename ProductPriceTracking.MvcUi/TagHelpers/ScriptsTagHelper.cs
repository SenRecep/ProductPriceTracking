using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPriceTracking.MvcUi.TagHelpers
{
    public class ScriptsTagHelper : TagHelper
    {
        private static readonly object Itemskey = new Object();

        private IDictionary<object, object> Items => _httpContextAccessor?.HttpContext?.Items;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ScriptsTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            context.AllAttributes.TryGetAttribute("render", out var attribute);

            var render = false;

            if (attribute != null)
            {
                render = Convert.ToBoolean(attribute.Value.ToString());
            }

            if (render && Items.ContainsKey(Itemskey))
            {
                var scripts = (List<HtmlString>)Items[Itemskey];
                var outputContent = String.Concat(scripts);
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

                var outputContent = await output.GetChildContentAsync();
                list.Add(new HtmlString(outputContent.GetContent()));
                output.Content.Clear();
            }
        }
    }
}
