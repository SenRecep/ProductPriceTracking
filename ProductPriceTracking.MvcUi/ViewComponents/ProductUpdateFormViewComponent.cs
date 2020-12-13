using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dto.ProductDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.Models;


namespace ProductPriceTracking.MvcUi.ViewComponents
{
    public class ProductUpdateFormViewComponent : ViewComponent
    {
        private readonly IGenericService<Product> productService;
        private readonly IMapper mapper;

        public ProductUpdateFormViewComponent(IGenericService<Product> productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(UpdateModalViewModel model)
        {
            ViewBag.ModalModel = new ModalViewModel(model.Name, model.Submit);
            Product product = await productService.GetByIdAsync(model.Id);
            ProductUpdateDto vm = product != null ? mapper.Map<ProductUpdateDto>(product) : new ProductUpdateDto();
            return View(vm);
        }
    }
}
