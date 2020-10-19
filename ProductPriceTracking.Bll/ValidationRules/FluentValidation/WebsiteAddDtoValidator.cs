using FluentValidation;
using ProductPriceTracking.Dto.WebsiteDtos;

namespace ProductPriceTracking.Bll.ValidationRules.FluentValidation
{
    public class WebsiteAddDtoValidator : AbstractValidator<WebsiteAddDto>
    {
        public WebsiteAddDtoValidator()
        {
            RuleFor(x => x.BaseUrl).NotEmpty().WithMessage("Url bilgisi Boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad bilgisi Boş geçilemez");
            RuleFor(x => x.Icon).NotNull().WithMessage("Icon bilgisi Boş geçilemez");
        }
    }
}
