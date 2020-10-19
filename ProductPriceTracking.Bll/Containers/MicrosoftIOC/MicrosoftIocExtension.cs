using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductPriceTracking.Bll.Concrete;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Bll.Mapping.AutoMapperProfile;
using ProductPriceTracking.Bll.StringInfo;
using ProductPriceTracking.Bll.ValidationRules.FluentValidation;
using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Contexts;
using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Repositories;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Dto.AppUserDtos;
using ProductPriceTracking.Dto.WebsiteDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPriceTracking.Bll.Containers.MicrosoftIOC
{
    public static class MicrosoftIocExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FolderInfo>(configuration.GetSection("UploadFileSources"));

            services.AddDbContext<ProductPriceTrackingDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString(configuration.GetValue<string>("ConnectionType")), cnf =>
                {
                    cnf.MigrationsAssembly("ProductPriceTracking.MvcUi");
                });
            });

            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppRoleService, AppRoleManager>();
            services.AddScoped<IUserRoleService, UserRoleManager>();
            services.AddScoped<IWebsiteService, WebsiteManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IWebsiteDal, EfWebsiteRepository>();


            services.AddHttpClient<IHtmlLoaderService,HtmlLoaderManager>();
        }
        public static void AddMapperDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AuthorizeProfile));
            services.AddAutoMapper(typeof(WebsiteProfile));
        }
        public static void AddValidationDependencies(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();
            services.AddTransient<IValidator<AppUserAddFormDto>, AppUserAddFormDtoValidator>();
            services.AddTransient<IValidator<WebsiteAddDto>, WebsiteAddDtoValidator>();
        }
    }
}
