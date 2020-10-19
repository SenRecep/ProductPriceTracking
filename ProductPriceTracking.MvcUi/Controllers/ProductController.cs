using Microsoft.AspNetCore.Mvc;

namespace ProductPriceTracking.MvcUi.Controllers
{
    public class ProductController : BaseController
    {
        [Route("Urun-Listesi")]
        public IActionResult ProductList()
        {
            return View();
        }
    }
}
