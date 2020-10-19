using FluentValidation;
using ProductPriceTracking.Dto.AppUserDtos;

namespace ProductPriceTracking.Bll.ValidationRules.FluentValidation
{
    public class AppUserAddFormDtoValidator : AbstractValidator<AppUserAddFormDto>
    {
        public AppUserAddFormDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanici adi alani bos gecilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alani bos gecilemez");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Parola Tekrar alanı boş geçilemez")
                .Equal(x => x.Password).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad ve soyad alani bos gecilemez");
        }
    }
}
