using Microsoft.AspNetCore.Mvc;
using ProductPriceTracking.Bll.StringInfo;
using ProductPriceTracking.MvcUi.Attributes.AuthorizeAttributes;
using System;

namespace ProductPriceTracking.MvcUi.Controllers
{
    [UserAuthorize(RoleInfo.Admin, RoleInfo.Developer)]
    public class BaseController : Controller
    {
        public IActionResult NotFoundPage(string title, string massage)
        {
            TempData.Add("ErrorTitle", title);
            TempData.Add("ErrorMassage", massage);
            return View("NotFoundPage");
        }
    }
}
