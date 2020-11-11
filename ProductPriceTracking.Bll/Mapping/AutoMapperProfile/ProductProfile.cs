using AutoMapper;
using ProductPriceTracking.Dto.ProductDtos;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Mapping.AutoMapperProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductAddDto>();
            CreateMap<ProductAddDto, Product>();

            CreateMap<Product, ProductUpdateDto>();
            CreateMap<ProductUpdateDto, Product>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
