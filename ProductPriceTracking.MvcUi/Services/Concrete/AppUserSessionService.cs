using Microsoft.AspNetCore.Http;

using ProductPriceTracking.Bll.StringInfo;
using ProductPriceTracking.Dto.AppUserDtos;
using ProductPriceTracking.MvcUi.ExtensionMethods;
using ProductPriceTracking.MvcUi.Services.Interfaces;

namespace ProductPriceTracking.MvcUi.Services.Concrete
{
    public class AppUserSessionService : IAppUserSessionService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AppUserSessionService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public AppUserDto Get()
        {
            return httpContextAccessor.HttpContext.Session.GetObj<AppUserDto>(SessionInfo.LoginUserSessionKey);
        }

        public void Remove()
        {
            httpContextAccessor.HttpContext.Session.Remove(SessionInfo.LoginUserSessionKey);
        }

        public void Set(AppUserDto value)
        {
            httpContextAccessor.HttpContext.Session.SetObj(SessionInfo.LoginUserSessionKey, value);
        }
    }
}
