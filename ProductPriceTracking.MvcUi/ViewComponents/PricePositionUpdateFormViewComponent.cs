using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dto.PricePositionDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.Models;
using System.Threading.Tasks;


namespace ProductPriceTracking.MvcUi.ViewComponents
{
    public class PricePositionUpdateFormViewComponent : ViewComponent
    {
        private readonly IGenericService<PricePosition> pricePositionService;
        private readonly IMapper mapper;

        public PricePositionUpdateFormViewComponent(IGenericService<PricePosition> PricePositionService, IMapper mapper)
        {
            this.pricePositionService = PricePositionService;
            this.mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(UpdateModalViewModel model)
        {
            ViewBag.ModalModel = new ModalViewModel(model.Name, model.Submit);
            PricePosition PricePosition = await pricePositionService.GetByIdAsync(model.Id);
            PricePositionUpdateDto vm = PricePosition != null ? mapper.Map<PricePositionUpdateDto>(PricePosition) : new PricePositionUpdateDto();
            return View(vm);
        }
    }
}
