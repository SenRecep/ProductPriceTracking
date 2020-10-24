using Microsoft.AspNetCore.Mvc.Rendering;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPriceTracking.MvcUi.Services.Concrete
{
    public class SelectListService : ISelectListService
    {
        private readonly IGenericRepository<Website> websiteService;

        public SelectListService(IGenericRepository<Website> websiteService)
        {
            this.websiteService = websiteService;
        }
        public async Task<IEnumerable<SelectListItem>> GetWebsites()
        {
            return (await websiteService.GetAllNotDeletedAsync())
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        }
    }
}
