using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

using ProductPriceTracking.Bll.ExtensionMethods;
using ProductPriceTracking.Dto.AppUserDtos;
using ProductPriceTracking.MvcUi.Services.Interfaces;

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
            if (user.IsNull())
                context.Result = new RedirectToActionResult("SignIn", "Auth", null);
            else if (Roles.Any())
            {
                string foundRole = Roles.FirstOrDefault(role => user.Roles.Contains(role));
                if (foundRole.EmptyCheck())
                    context.Result = new RedirectToActionResult("AccessDenied", "Auth", null);
            }
        }
    }
}
