using System;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using ProductPriceTracking.Bll.ExtensionMethods;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dto.ProductDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.ExtensionMethods;
using ProductPriceTracking.MvcUi.Services.Interfaces;

namespace ProductPriceTracking.MvcUi.Controllers
{

    public class ProductController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IAppUserSessionService appUserSessionService;
        private readonly IGenericService<Product> productService;
        public ProductController(IServiceProvider serviceProvider)
        {
            mapper = serviceProvider.GetService<IMapper>();
            appUserSessionService = serviceProvider.GetService<IAppUserSessionService>();
            productService = serviceProvider.GetService<IGenericService<Product>>();
        }
        [HttpGet]
        [Route("Urun-Listesi")]
        public IActionResult ProductList()
        {
            return View();
        }
        [HttpGet]
        [Route("Urun-Ekle")]
        [Route("Urun-Ekle/{websiteId:int}")]
        public IActionResult ProductAdd(int websiteId = 0)
        {
            return View(new ProductAddDto() { WebsiteId = websiteId });
        }
        [HttpPost]
        [Route("Urun-Ekle")]
        [Route("Urun-Ekle/{webisteId:int}")]
        public async Task<IActionResult> ProductAdd(ProductAddDto model)
        {
            if (ModelState.IsValid)
            {
                Product product = mapper.Map<Product>(model);
                product.CreateUserId = appUserSessionService.Get().Id;
                await productService.AddAsync(product);
                return RedirectToAction("ProductList");
            }
            else
            {
                ModelState.AddModelError("", "Lütfen gerekli tüm alanları doldurun.");
                return View(model);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> ProductDelete(int id)
        {
            Product found = await productService.GetByIdAsync(id);
            if (found != null)
                await productService.RemoveAsync(found);
            return Json($"{id} id li ürün silindi");
        }
        [HttpPut]
        public async Task<IActionResult> ProductUpdate(ProductUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                Product product = await productService.GetByIdAsync(model.Id);
                if (product != null)
                {
                    product.Transfer(model);
                    product.UpdateUserId = appUserSessionService.Get().Id;
                    await productService.UpdateAsync(product);
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
