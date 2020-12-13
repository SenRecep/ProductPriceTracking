using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Bll.StringInfo;
using ProductPriceTracking.Dto.AppUserDtos;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.ComplexTypes
{

    public static class SeedDatabase
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            IAppUserService appUserService = serviceProvider.GetService<IAppUserService>();
            IUserRoleService UserRoleService = serviceProvider.GetService<IUserRoleService>();
            IAppRoleService appRoleService = serviceProvider.GetService<IAppRoleService>();
            IGenericService<AppUser> userService = serviceProvider.GetService<IGenericService<AppUser>>();
            IGenericService<AppRole> roleService = serviceProvider.GetService<IGenericService<AppRole>>();
            IGenericService<UserRole> userRoleService = serviceProvider.GetService<IGenericService<UserRole>>();


            AppRole adminRole = await CheckRole(appRoleService, roleService, RoleInfo.Admin);
            await CheckRole(appRoleService, roleService, RoleInfo.Member);//Member Role
            AppRole developerRole = await CheckRole(appRoleService, roleService, RoleInfo.Developer);

            AppUser developerUser = await CheckUser(appUserService, userService, new AppUserAddDto() { UserName = "Daniga", Password = "591bdce09bf3f26abdf8990689693e8b", FullName = "Recep Şen" });

            await UserAddRole(UserRoleService, userRoleService, developerUser, developerRole);
            await UserAddRole(UserRoleService, userRoleService, developerUser, adminRole);
        }
        private static async Task<AppRole> CheckRole(IAppRoleService appRoleService, IGenericService<AppRole> roleService, string roleName)
        {
            AppRole role = await appRoleService.FindByName(roleName);
            if (role == null)
            {
                role = new AppRole() { Name = roleName };
                await roleService.AddAsync(role);
            }
            return role;
        }
        private static async Task<AppUser> CheckUser(IAppUserService appUserService, IGenericService<AppUser> userService, AppUserAddDto appUserAddDto)
        {
            AppUser user = await appUserService.FindByUserName(appUserAddDto.UserName);
            if (user == null)
            {
                user = new AppUser()
                {
                    UserName = appUserAddDto.UserName,
                    FullName = appUserAddDto.FullName,
                    Password = appUserAddDto.Password
                };
                await userService.AddAsync(user);
            }
            return user;
        }
        private static async Task UserAddRole(IUserRoleService UserRoleService, IGenericService<UserRole> userRoleService, AppUser appUser, AppRole appRole)
        {
            if (!await UserRoleService.CheckUserRole(appUser.Id, appRole.Id))
            {
                await userRoleService.AddAsync(new UserRole()
                {
                    AppRoleId = appRole.Id,
                    AppUserId = appUser.Id
                });
            }
        }
    }
}
