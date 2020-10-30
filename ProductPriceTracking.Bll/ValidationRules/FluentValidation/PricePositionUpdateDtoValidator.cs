using FluentValidation;
using ProductPriceTracking.Dto.PricePositionDtos;

namespace ProductPriceTracking.Bll.ValidationRules.FluentValidation
{
    public class PricePositionUpdateDtoValidator : AbstractValidator<PricePositionUpdateDto>
    {
        public PricePositionUpdateDtoValidator()
        {
            RuleFor(x => x.XPath).NotEmpty().WithMessage("XPath alanı boş geçilemez");
            RuleFor(x => x.Priority).InclusiveBetween(int.MinValue, int.MaxValue).WithMessage("Lütfen geçerli bir öncelik bilgisi seçiniz");
            RuleFor(x => x.WebsiteId).InclusiveBetween(1, int.MaxValue).WithMessage("Lütfen geçerli bir website bilgisi seçiniz");
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Lütfen geçerli bir para konum bilgisi üzerinde işlem gerçekleştirin");
        }
    }
}
