using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ProductPriceTracking.Bll.ExtensionMethods;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dto.AppUserDtos;
using ProductPriceTracking.Dto.HtmlLoaderDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.Services.Interfaces;

namespace ProductPriceTracking.MvcUi.Controllers
{
    public class TrackingController : BaseController
    {
        private readonly IAppUserSessionService appUserSessionService;
        private readonly IUserWebsiteService userWebsiteService;
        private readonly IWebsiteService websiteService;
        private readonly ITrackingRecordService trackingRecordService;
        private readonly IGenericService<PricePosition> pricePositionService;
        private readonly IHtmlLoaderService htmlLoaderService;



        public TrackingController(IAppUserSessionService appUserSessionService, IUserWebsiteService userWebsiteService, IWebsiteService websiteService, ITrackingRecordService trackingRecordService, IGenericService<PricePosition> pricePositionService, IHtmlLoaderService htmlLoaderService)
        {
            this.appUserSessionService = appUserSessionService;
            this.userWebsiteService = userWebsiteService;
            this.websiteService = websiteService;
            this.trackingRecordService = trackingRecordService;
            this.pricePositionService = pricePositionService;
            this.htmlLoaderService = htmlLoaderService;
        }

        [HttpGet]
        [Route("Test")]
        public async Task<IActionResult> Index()
        {
            AppUserDto loginUser = appUserSessionService.Get();
            ICollection<Website> userWebsites = await userWebsiteService.GetWebsitesByUserId(loginUser.Id);

            return View(userWebsites);
        }
    }
}
