using HtmlAgilityPack;
using ProductPriceTracking.Dto.HtmlLoaderDtos;
using System.Threading.Tasks;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface IHtmlLoaderService
    {
        public Task<HtmlLoaderResponse> GetWebsiteContentByUrlAsync(string url);
        public HtmlDocument GetHtmlDocumentByHtmlLoaderResponse(HtmlLoaderResponse response);
    }
}
