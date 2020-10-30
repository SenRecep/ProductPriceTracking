using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ProductPriceTracking.Bll.ExtensionMethods;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dto.TrackingRecordDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.ExtensionMethods;
using ProductPriceTracking.MvcUi.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace ProductPriceTracking.MvcUi.Controllers
{
    public class TrackingRecordController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IAppUserSessionService appUserSessionService;
        private readonly IGenericService<TrackingRecord> trackingRecordService;
        public TrackingRecordController(IServiceProvider serviceProvider)
        {
            mapper = serviceProvider.GetService<IMapper>();
            appUserSessionService = serviceProvider.GetService<IAppUserSessionService>();
            trackingRecordService = serviceProvider.GetService<IGenericService<TrackingRecord>>();
        }
        [HttpGet]
        [Route("Takipci-Listesi/{productId:int}")]
        public async Task<IActionResult> TrackingRecordList(int productId)
        {
            return View();
        }

        [HttpGet]
        [Route("Takipci-Ekle")]
        [Route("Takipci-Ekle/{productId:int}")]
        public IActionResult TrackingRecordAdd(int productId = 0)
        {
            return View(new TrackingRecordAddDto() { ProductId = productId });
        }
        [HttpPost]
        [Route("Takipci-Ekle")]
        [Route("Takipci-Ekle/{productId:int}")]
        public async Task<IActionResult> TrackingRecordAdd(TrackingRecordAddDto model)
        {
            if (ModelState.IsValid)
            {
                TrackingRecord trackingRecord = mapper.Map<TrackingRecord>(model);
                trackingRecord.CreateUserId = appUserSessionService.Get().Id;
                await trackingRecordService.AddAsync(trackingRecord);
                return RedirectToAction("TrackingRecordList");
            }
            else
            {
                ModelState.AddModelError("", "Lütfen gerekli tüm alanları doldurun.");
                return View(model);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> TrackingRecordDelete(int id)
        {
            TrackingRecord found = await trackingRecordService.GetByIdAsync(id);
            if (found != null)
                await trackingRecordService.RemoveAsync(found);
            return Json($"{id} id li ürün silindi");
        }
        [HttpPut]
        public async Task<IActionResult> TrackingRecordUpdate(TrackingRecordUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                TrackingRecord trackingRecord = await trackingRecordService.GetByIdAsync(model.Id);
                if (trackingRecord != null)
                {
                    trackingRecord.Transfer(model);
                    trackingRecord.UpdateUserId = appUserSessionService.Get().Id;
                    await trackingRecordService.UpdateAsync(trackingRecord);
                    return Json(new { IsOk = true, Massage = "Ürün Guncellendi" });
                }
                else
                {
                    ModelState.AddModelError("", "Lütfen verilerı manipüle etmeyiniz");
                    string messages = ModelState.GetErrorsString();
                    return Json(new { IsOk = false, Massage = messages });
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen gerekli tüm alanları doldurun.");
                string messages = ModelState.GetErrorsString();
                return Json(new { IsOk = false, Massage = messages });
            }
        }
    }
}
