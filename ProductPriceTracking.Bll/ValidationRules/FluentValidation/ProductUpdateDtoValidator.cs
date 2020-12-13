using FluentValidation;

using ProductPriceTracking.Dto.ProductDtos;

namespace ProductPriceTracking.Bll.ValidationRules.FluentValidation
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url alanı boş geçilemez");
            RuleFor(x => x.WebsiteId).InclusiveBetween(1, int.MaxValue).WithMessage("Lütfen geçerli bir website bilgisi seçiniz");
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Lütfen geçerli bir ürün bilgisi üzerinde işlem gerçekleştirin");
        }
    }
}

