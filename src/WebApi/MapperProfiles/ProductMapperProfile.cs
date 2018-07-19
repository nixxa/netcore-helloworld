using AutoMapper;
using Models;
using WebModels;

namespace WebApi.MapperProfiles
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductReadModel>();
            CreateMap<ProductReadModel, Product>();
        }
    }
}