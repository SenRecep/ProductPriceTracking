using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductPriceTracking.Bll.Containers.MicrosoftIOC;
using ProductPriceTracking.MvcUi.Helpers;
using ProductPriceTracking.MvcUi.Services.Concrete;
using ProductPriceTracking.MvcUi.Services.Interfaces;
using System;

namespace ProductPriceTracking.MvcUi.Containers.MicrosoftIOC
{
    public static class CustomIocExtension
    {
        public static void AddAllDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDependencies(configuration);
            services.AddMapperDependencies();
            services.AddValidationDependencies();
            services.AddServicesDependencies();
            services.AddAttributeDependencies();
            services.AddHelperDependencies();
        }
        public static void AddServicesDependencies(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IAppUserSessionService, AppUserSessionService>();
            services.AddScoped<ISelectListService, SelectListService>();
        }
        public static void AddAttributeDependencies(this IServiceCollection services)
        {

        }

        public static void AddHelperDependencies(this IServiceCollection services)
        {
            services.AddScoped<AccountHelper>();
            services.AddScoped<FileHelper>();
        }
        public static void AddCustomControllerServices(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddFluentValidation();
        }
    }
}
