using FluentValidation;
using ProductPriceTracking.Dto.AppUserDtos;

namespace ProductPriceTracking.Bll.ValidationRules.FluentValidation
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanici adi bos gecilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola bilgisi bos gecilemez");
        }
    }
}
