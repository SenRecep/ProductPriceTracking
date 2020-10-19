using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ProductPriceTracking.Dto.AppUserDtos;
using ProductPriceTracking.MvcUi.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductPriceTracking.MvcUi.Attributes.AuthorizeAttributes
{
    public class UserAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public List<string> Roles { get; set; }
        public UserAuthorizeAttribute(params string[] roles)
        {
            Roles = roles.ToList();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            AppUserDto user = context.HttpContext.RequestServices.GetService<IAppUserSessionService>().Get();
            if (user == null)
                context.Result = new RedirectToActionResult("SignIn", "Auth", null);
            else if (Roles.Count > 0)
            {
                string existRole = Roles.FirstOrDefault(role => user.Roles.Contains(role));
                if (existRole == null)
                    context.Result = new RedirectToActionResult("AccessDenied", "Auth", null);
            }
        }
    }
}
