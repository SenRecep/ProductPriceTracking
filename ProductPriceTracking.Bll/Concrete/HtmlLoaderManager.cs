using HtmlAgilityPack;
using ProductPriceTracking.Bll.ExtensionMethods;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dto.HtmlLoaderDtos;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductPriceTracking.Bll.Concrete
{
    public class HtmlLoaderManager : IHtmlLoaderService
    {
        private readonly HttpClient httpClient;
        public HtmlLoaderManager(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HtmlLoaderResponse> GetWebsiteContentByUrlAsync(string url)
        {
            HtmlLoaderResponse response = new HtmlLoaderResponse();
            if (url.EmptyCheck())
            {
                response.ErrorMassage = "Url bilgisi boş olamaz";
                response.Status = HtmlLoaderStatus.Error;
                return response;
            }
            try
            {
                using HttpResponseMessage httpResponse = await httpClient.GetAsync(url);
                if (httpResponse.IsSuccessStatusCode)
                {
                    using HttpContent strContent = httpResponse.Content;
                    string result = await strContent.ReadAsStringAsync();
                    if (result.EmptyCheck())
                    {
                        response.ErrorMassage = "Yüklenen sayfada içerik yok";
                        response.Status = HtmlLoaderStatus.NoContent;
                        return response;
                    }
                    response.Content = result;
                    response.Status = HtmlLoaderStatus.Success;
                    return response;
                }
                else
                {
                    response.ErrorMassage = "Sayfa yüklenirken hata ile karşılaşıldı";
                    response.Status = HtmlLoaderStatus.Error;
                    return response;
                }
            }
            catch
            {
                response.ErrorMassage = "Hay aksi beklenmeyen bir durum oldu.\nLinkleri kontrol edin";
                response.Status = HtmlLoaderStatus.Error;
                return response;
            }

        }
        public HtmlDocument GetHtmlDocumentByHtmlLoaderResponse(HtmlLoaderResponse response)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            if (response.Status == HtmlLoaderStatus.Success)
            {
                htmlDocument.LoadHtml(response.Content);
            }
            return htmlDocument;
        }
    }
}
