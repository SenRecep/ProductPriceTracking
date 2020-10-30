using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPriceTracking.MvcUi.Services.Interfaces
{
    public interface ISelectListService
    {
        Task<IEnumerable<SelectListItem>> GetWebsites();
        Task<IEnumerable<SelectListItem>> GetProducts();
    }
}
