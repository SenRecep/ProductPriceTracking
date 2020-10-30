using FluentValidation;
using ProductPriceTracking.Dto.PricePositionDtos;

namespace ProductPriceTracking.Bll.ValidationRules.FluentValidation
{
    public class PricePositionAddDtoValidator : AbstractValidator<PricePositionAddDto>
    {
        public PricePositionAddDtoValidator()
        {
            RuleFor(x => x.XPath).NotEmpty().WithMessage("XPath alanı boş geçilemez");
            RuleFor(x => x.Priority).InclusiveBetween(int.MinValue, int.MaxValue).WithMessage("Lütfen geçerli bir öncelik bilgisi seçiniz");
            RuleFor(x => x.WebsiteId).InclusiveBetween(1, int.MaxValue).WithMessage("Lütfen geçerli bir website bilgisi seçiniz");
        }
    }
}
