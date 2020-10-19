using Microsoft.AspNetCore.Mvc;
using ProductPriceTracking.Dto.WebsiteDtos;
using ProductPriceTracking.MvcUi.Models;
using System.Threading.Tasks;

namespace ProductPriceTracking.MvcUi.ViewComponents
{
    public class WebsiteCreateFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ModalViewModel model)
        {
            ViewBag.ModalModel = model;
            return View(new WebsiteAddDto());
        }
    }
}
