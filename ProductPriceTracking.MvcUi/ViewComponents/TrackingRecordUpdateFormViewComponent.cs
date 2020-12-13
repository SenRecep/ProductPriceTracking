using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dto.TrackingRecordDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.Models;


namespace ProductPriceTracking.MvcUi.ViewComponents
{
    public class TrackingRecordUpdateFormViewComponent : ViewComponent
    {
        private readonly IGenericService<TrackingRecord> trackingRecordService;
        private readonly IMapper mapper;

        public TrackingRecordUpdateFormViewComponent(IGenericService<TrackingRecord> trackingRecordService, IMapper mapper)
        {
            this.trackingRecordService = trackingRecordService;
            this.mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(UpdateModalViewModel model)
        {
            ViewBag.ModalModel = new ModalViewModel(model.Name, model.Submit);
            TrackingRecord trackingRecord = await trackingRecordService.GetByIdAsync(model.Id);
            TrackingRecordUpdateDto vm = trackingRecord != null ? mapper.Map<TrackingRecordUpdateDto>(trackingRecord) : new TrackingRecordUpdateDto();
            return View(vm);
        }
    }
}
