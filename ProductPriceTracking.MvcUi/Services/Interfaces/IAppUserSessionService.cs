using ProductPriceTracking.Dto.AppUserDtos;

namespace ProductPriceTracking.MvcUi.Services.Interfaces
{
    public interface IAppUserSessionService
    {
        public void Set(AppUserDto value);
        public AppUserDto Get();
        public void Remove();
    }
}