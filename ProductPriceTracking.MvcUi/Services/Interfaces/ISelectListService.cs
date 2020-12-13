using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductPriceTracking.MvcUi.Services.Interfaces
{
    public interface ISelectListService
    {
        Task<IEnumerable<SelectListItem>> GetWebsites();
        Task<IEnumerable<SelectListItem>> GetProducts();
    }
}
