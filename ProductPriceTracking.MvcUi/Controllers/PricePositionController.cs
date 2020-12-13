using System;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using ProductPriceTracking.Bll.ExtensionMethods;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dto.PricePositionDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.ExtensionMethods;
using ProductPriceTracking.MvcUi.Services.Interfaces;

namespace ProductPriceTracking.MvcUi.Controllers
{
    public class PricePositionController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IAppUserSessionService appUserSessionService;
        private readonly IGenericService<PricePosition> pricePositionService;

        public PricePositionController(IServiceProvider serviceProvider)
        {
            mapper = serviceProvider.GetService<IMapper>();
            appUserSessionService = serviceProvider.GetService<IAppUserSessionService>();
            pricePositionService = serviceProvider.GetService<IGenericService<PricePosition>>();
        }
        [HttpGet]
        [Route("ParaKonumlari")]
        public IActionResult PricePositionList()
        {
            return View();
        }

        [HttpGet]
        [Route("ParaKonum-Ekle")]
        [Route("ParaKonum-Ekle/{websiteId:int}")]
        public IActionResult PricePositionAdd(int websiteId = 0)
        {
            return View(new PricePositionAddDto() { WebsiteId = websiteId });
        }

        [HttpPost]
        [Route("ParaKonum-Ekle")]
        [Route("ParaKonum-Ekle/{websiteId:int}")]

        public async Task<IActionResult> PricePositionAdd(PricePositionAddDto model)
        {
            if (ModelState.IsValid)
            {
                PricePosition pricePosition = mapper.Map<PricePosition>(model);
                pricePosition.CreateUserId = appUserSessionService.Get().Id;
                await pricePositionService.AddAsync(pricePosition);
                return RedirectToAction("PricePositionList");
            }
            else
            {
                ModelState.AddModelError("", "Lütfen gerekli tüm alanları doldurun.");
                return View(model);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> PricePositionDelete(int id)
        {
            PricePosition found = await pricePositionService.GetByIdAsync(id);
            if (found != null)
                await pricePositionService.RemoveAsync(found);
            return Json($"{id} id li ürün silindi");
        }
        [HttpPut]
        public async Task<IActionResult> PricePositionUpdate(PricePositionUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                PricePosition pricePosition = await pricePositionService.GetByIdAsync(model.Id);
                if (pricePosition != null)
                {
                    pricePosition.Transfer(model);
                    pricePosition.UpdateUserId = appUserSessionService.Get().Id;
                    await pricePositionService.UpdateAsync(pricePosition);
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
