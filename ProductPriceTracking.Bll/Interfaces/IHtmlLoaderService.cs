using System.Threading.Tasks;

using HtmlAgilityPack;

using ProductPriceTracking.Dto.HtmlLoaderDtos;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface IHtmlLoaderService
    {
        public Task<HtmlLoaderResponse> GetWebsiteContentByUrlAsync(string url);
        public HtmlDocument GetHtmlDocumentByHtmlLoaderResponse(HtmlLoaderResponse response);
        public Task<HtmlDocument> GetHtmlDocumentByHtmlLoaderResponseAsync(string url);

    }
}
