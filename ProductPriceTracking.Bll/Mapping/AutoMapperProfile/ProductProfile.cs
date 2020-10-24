using AutoMapper;
using ProductPriceTracking.Dto.ProductDtos;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Mapping.AutoMapperProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductAddtDto>();
            CreateMap<ProductAddtDto, Product>();
        }
    }
}
