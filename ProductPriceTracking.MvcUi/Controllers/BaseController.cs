using Microsoft.AspNetCore.Mvc;
using ProductPriceTracking.Bll.StringInfo;
using ProductPriceTracking.MvcUi.Attributes.AuthorizeAttributes;

namespace ProductPriceTracking.MvcUi.Controllers
{
    [UserAuthorize(RoleInfo.Admin,RoleInfo.Developer)]
    public class BaseController : Controller
    {
    }
}
