using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dto.WebsiteDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.Models;
using System.Threading.Tasks;

namespace ProductPriceTracking.MvcUi.ViewComponents
{
    public class WebsiteUpdateFormViewComponent : ViewComponent
    {
        private readonly IGenericService<Website> websiteService;
        private readonly IMapper mapper;

        public WebsiteUpdateFormViewComponent(IGenericService<Website> websiteService, IMapper mapper)
        {
            this.websiteService = websiteService;
            this.mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(UpdateModalViewModel model)
        {
            ViewBag.ModalModel = new ModalViewModel(model.Name, model.Submit);
            Website website = await websiteService.GetByIdAsync(model.Id);
            WebsiteUpdateDto vm;
            if (website != null)
                vm = mapper.Map<WebsiteUpdateDto>(website);
            else
                vm = new WebsiteUpdateDto();
            return View(vm);
        }
    }
}
