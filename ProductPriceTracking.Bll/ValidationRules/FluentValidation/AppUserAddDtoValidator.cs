using FluentValidation;

using ProductPriceTracking.Dto.AppUserDtos;

namespace ProductPriceTracking.Bll.ValidationRules.FluentValidation
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanici adi alani bos gecilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alani bos gecilemez");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad ve soyad alani bos gecilemez");
        }
    }
}
