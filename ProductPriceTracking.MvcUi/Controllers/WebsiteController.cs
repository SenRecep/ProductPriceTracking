using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductPriceTracking.Bll.ExtensionMethods;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Bll.StringInfo;
using ProductPriceTracking.Dto.WebsiteDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.Enums;
using ProductPriceTracking.MvcUi.ExtensionMethods;
using ProductPriceTracking.MvcUi.Helpers;
using ProductPriceTracking.MvcUi.Models;
using ProductPriceTracking.MvcUi.Services.Interfaces;
using System;
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
            logger = serviceProvider.GetService<ILogger<WebsiteController>>();
        }
        [HttpGet]
        [Route("Website-Listesi")]
        public IActionResult WebsiteList()
        {
            return View();
        }

        [HttpGet]
        [Route("Website-Ekle")]
        public IActionResult WebsiteAdd()
        {
            return View(new WebsiteAddDto());
        }

        [HttpPost]
        [Route("Website-Ekle")]
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
                    return View(websiteAddDto);
                }
                website.CreateUserId = appUserSessionService.Get().Id;
                await websiteService.AddAsync(website);
                logger.LogInformation($"{ website.CreateUserId} id li kullanici yeni bir website olusturdu");
                return RedirectToAction("WebsiteAdd");
            }
            else
            {
                ModelState.AddModelError("", "Lütfen gerekli tüm alanları doldurun.");

                return View(websiteAddDto);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> WebsiteDelete(int id)
        {
            Website found = await websiteService.GetByIdAsync(id);
            if (found != null)
            {
                await websiteService.RemoveAsync(found);
            }
            return Json($"{id} id li website silindi");
        }
        [HttpPut]
        public async Task<IActionResult> WebsiteUpdate(WebsiteUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                Website website = await websiteService.GetByIdAsync(model.Id.Value);
                if (website != null)
                {
                    website.Transfer(model);
                    if (model.Icon != null)
                    {
                        fileHelper.UploadedFileDelete(model.IconName, folderInfo.WebsiteIcons);
                        UploadModel uploadResult = await fileHelper.UploadImage(model.Icon, folderInfo.WebsiteIcons);
                        if (uploadResult.UploadState == UploadState.Success)
                            website.IconName = uploadResult.NewName;
                        else
                        {
                            ModelState.AddModelError("", uploadResult.ErrorMessage);
                            string messages = ModelState.GetErrorsString();
                            return Json(new { IsOk = false, Massage = messages });
                        }
                    }

                    website.UpdateUserId = appUserSessionService.Get().Id;
                    await websiteService.UpdateAsync(website);
                    logger.LogInformation($"{ website.UpdateUserId} id li kullanici {website.Id} li websiteyi guncelledi");
                    return Json(new { IsOk = true, Massage = "Website Guncellendi" });
                }
                else
                {
                    ModelState.AddModelError("", "Lütfen verilerı manipüle etmeyiniz");
                    string messages = ModelState.GetErrorsString();
                    return Json(new { IsOk = false, Massage = messages });
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen gerekli tüm alanları doldurun.");
                string messages = ModelState.GetErrorsString();
                return Json(new { IsOk = false, Massage = messages });
            }
        }
    }
}
