using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Bll.StringInfo;
using ProductPriceTracking.Dto.WebsiteDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.Enums;
using ProductPriceTracking.MvcUi.Helpers;
using ProductPriceTracking.MvcUi.Models;
using ProductPriceTracking.MvcUi.Services.Concrete;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPriceTracking.MvcUi.Controllers
{
    public class WebsiteController : BaseController
    {
        private readonly FolderInfo folderInfo;
        private readonly FileHelper fileHelper;
        private readonly IMapper mapper;
        private readonly ILogger<WebsiteController> logger;
        private readonly IGenericService<Website> websiteService;
        private readonly IAppUserSessionService appUserSessionService;


        public WebsiteController(IServiceProvider serviceProvider)
        {
            folderInfo = serviceProvider.GetService<IOptions<FolderInfo>>().Value;
            fileHelper = serviceProvider.GetService<FileHelper>();
            mapper = serviceProvider.GetService<IMapper>();
            websiteService = serviceProvider.GetService<IGenericService<Website>>();
            appUserSessionService = serviceProvider.GetService<IAppUserSessionService>();
        }
        [HttpGet]
        [Route("Website-Listesi")]
        public IActionResult WebsiteList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WebsiteAdd(WebsiteAddDto websiteAddDto)
        {
            if (ModelState.IsValid)
            {
                Website website = mapper.Map<Website>(websiteAddDto);
                UploadModel uploadResult = await fileHelper.UploadImage(websiteAddDto.Icon, folderInfo.WebsiteIcons);
                if (uploadResult.UploadState == UploadState.Success)
                    website.IconName = uploadResult.NewName;
                else
                {
                    ModelState.AddModelError("", uploadResult.ErrorMessage);
                    string messages = string.Join("<br/>", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    return Json(new { IsOk = false, Massage = messages });
                }
                website.CreateUserId = appUserSessionService.Get().Id;
                await websiteService.AddAsync(website);
                logger.LogInformation($"{ website.CreateUserId} id li kullanici yeni bir website olusturdu");
                return Json(new { IsOk = true, Massage = "Website Eklendi" });
            }
            else
            {
                ModelState.AddModelError("", "Lütfen gerekli tüm alanları doldurun.");
                string messages = string.Join("<br/>", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return Json(new { IsOk=false,Massage= messages });
            }
        }
    }
}
