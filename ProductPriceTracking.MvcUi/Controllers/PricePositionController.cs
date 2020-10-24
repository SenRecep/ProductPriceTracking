using Microsoft.AspNetCore.Mvc;

namespace ProductPriceTracking.MvcUi.Controllers
{
    public class PricePositionController : BaseController
    {
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
            return View();
        }
    }
}
