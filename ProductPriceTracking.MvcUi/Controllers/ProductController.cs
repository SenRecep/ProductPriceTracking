using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dto.ProductDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.Services.Interfaces;
using System;
using System.Threading.Tasks;

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
            return View(new ProductAddtDto() { WebsiteId = websiteId });
        }
        [HttpPost]
        [Route("Urun-Ekle")]
        [Route("Urun-Ekle/{webisteId:int}")]
        public async Task<IActionResult> ProductAdd(ProductAddtDto model,int websiteId=0)
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
    }
}
