using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProductPriceTracking.MvcUi.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult GlobalError()
        {
            IExceptionHandlerPathFeature errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError("GENEL HATA YAKALAMA SISTEMI");
            logger.LogError(errorInfo.Path);
            logger.LogError(errorInfo.Error.Message);
            logger.LogError(errorInfo.Error.StackTrace);
            return Problem("api da bir problem olustu, en kisa surede duzeltecek");
        }
    }
}
