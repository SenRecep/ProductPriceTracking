using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductPriceTracking.Bll.Helpers;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Bll.StringInfo;
using ProductPriceTracking.Dto.AppUserDtos;
using ProductPriceTracking.Entities.Concrete;
using ProductPriceTracking.MvcUi.Helpers;
using ProductPriceTracking.MvcUi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPriceTracking.MvcUi.Controllers
{
    public class AuthController : Controller
    {
        #region Services
        private readonly IMapper mapper;
        private readonly IAppUserService appUserService;
        private readonly IGenericService<AppUser> userService;
        private readonly IGenericService<UserRole> userRoleService;
        private readonly IAppRoleService appRoleService;
        private readonly ILogger<AuthController> logger;
        private readonly IAppUserSessionService appUserSessionService;
        private readonly AccountHelper accountHelper;
        #endregion

        public AuthController(IServiceProvider serviceProvider)
        {
            appUserService = serviceProvider.GetService<IAppUserService>();
            userService = serviceProvider.GetService<IGenericService<AppUser>>();
            userRoleService = serviceProvider.GetService<IGenericService<UserRole>>();
            appRoleService = serviceProvider.GetService<IAppRoleService>();
            mapper = serviceProvider.GetService<IMapper>();
            logger = serviceProvider.GetService<ILogger<AuthController>>();
            appUserSessionService = serviceProvider.GetService<IAppUserSessionService>();
            accountHelper = serviceProvider.GetService<AccountHelper>();
        }

        #region SignIn
        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new AppUserLoginDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(AppUserLoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await appUserService.FindByUserName(loginDto.UserName);
                if (appUserService.CheckPassword(loginDto, appUser) && appUser != null)
                {
                    ICollection<AppRole> roles = await appUserService.GetRolesByUserName(loginDto.UserName);
                    AppUserDto appUserDto = accountHelper.GenerateAppUserDto(appUser, roles);
                    appUserSessionService.Set(appUserDto);
                    logger.LogInformation($"{appUser.UserName} kullanıcısı giriş yaptı");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    logger.LogInformation($"{loginDto.UserName} Kullanici adi veya parola hatali ");
                    ModelState.AddModelError("", "Kullanici adi veya parola hatali");
                    return View(loginDto);
                }
            }
            else
            {
                logger.LogInformation("AppUserLoginDto Not Valid");
                ModelState.AddModelError("", "Lütfen gereken tüm alanları doldurunuz");
                return View(loginDto);
            }
        }
        #endregion

        #region SignUp
        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new AppUserAddFormDto());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(AppUserAddFormDto appUserAddDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await appUserService.FindByUserName(appUserAddDto.UserName);
                if (appUser != null)
                {
                    logger.LogInformation($"{appUser.UserName} Kullanici adi zaten alınmış");
                    ModelState.AddModelError("", $"{appUser.UserName} kullanıcı adı zaten alınmış");
                    return View(appUserAddDto);
                }

                appUserAddDto.Password = ToPasswordRepository.PasswordCryptographyCombine(appUserAddDto.Password);
                appUser = mapper.Map<AppUser>(appUserAddDto);
                await userService.AddAsync(appUser);
                logger.LogInformation($"{appUser.UserName} Kullanici olusturuldu");

                AppRole memberRole = await appRoleService.FindByName(RoleInfo.Member);
                await userRoleService.AddAsync(new UserRole()
                {
                    AppRoleId = memberRole.Id,
                    AppUserId = appUser.Id
                });
                logger.LogInformation($"{appUser.UserName} Kullanicisina varsayilan rol bilgisi eklendi");
                return RedirectToAction("SignIn");
            }
            else
            {
                logger.LogInformation("AppUserAddDto Not Valid");
                ModelState.AddModelError("", "Lütfen gereken tüm alanları doldurunuz.");
                return View(appUserAddDto);
            }
        }
        #endregion

        [HttpGet]
        public IActionResult AccessDenied()
        {
            ViewBag.AccessDenied = $"Bu sayfaya yada özelliğe erişiminiz mevcut değildir.";
            ViewBag.AccessDenied2 = $"Lütfen sistem yetkilisi ile iletişime geçiniz.";
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            appUserSessionService.Remove();
            return RedirectToAction("SignIn");
        }

    }
}
