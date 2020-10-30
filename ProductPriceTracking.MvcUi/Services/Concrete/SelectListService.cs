using AutoMapper.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductPriceTracking.Bll.Interfaces;
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
        private readonly IWebsiteService websiteService;
        private readonly IGenericRepository<Website> websiteGenericService;

        public SelectListService(IGenericRepository<Website> websiteGenericService, IWebsiteService websiteService)
        {
            this.websiteGenericService = websiteGenericService;
            this.websiteService = websiteService;
        }

        public async Task<IEnumerable<SelectListItem>> GetProducts()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var websites = await websiteService.GetWebsites();
            websites.ForAll(website =>
            {
                var group = new SelectListGroup() { Name = website.Name };
                items.AddRange(website.Products.Select(x => new SelectListItem(x.Name, x.Id.ToString()) { Group = group }));
            });
            return items;

        }

        public async Task<IEnumerable<SelectListItem>> GetWebsites()
        {
            return (await websiteGenericService.GetAllNotDeletedAsync())
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        }

    }
}
