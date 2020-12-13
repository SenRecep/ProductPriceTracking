using FluentValidation;

using ProductPriceTracking.Dto.WebsiteDtos;

namespace ProductPriceTracking.Bll.ValidationRules.FluentValidation
{
    public class WebsiteUpdateDtoValidator : AbstractValidator<WebsiteUpdateDto>
    {
        public WebsiteUpdateDtoValidator()
        {
            RuleFor(x => x.Id).ExclusiveBetween(0, int.MaxValue).WithMessage("Geçersiz website bilgisi");
            RuleFor(x => x.BaseUrl).NotEmpty().WithMessage("Url bilgisi Boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad bilgisi Boş geçilemez");
        }
    }
}
