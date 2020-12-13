using FluentValidation;

using ProductPriceTracking.Dto.ProductDtos;

namespace ProductPriceTracking.Bll.ValidationRules.FluentValidation
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url alanı boş geçilemez");
            RuleFor(x => x.WebsiteId).InclusiveBetween(1, int.MaxValue).WithMessage("Lütfen geçerli bir website bilgisi seçiniz");
        }
    }
}
