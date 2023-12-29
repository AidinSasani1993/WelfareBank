using AutoMapper;
using Refah.Application.Dtos.Product_Dtos;
using Refah.Application.Dtos.ProductCategory_Dtos;
using Refah.Domain.Aggregates;

namespace Refah.Application.Profiles
{
    public class Auto_Map : Profile
    {
        #region [-ctor-]
        public Auto_Map()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
        } 
        #endregion
    }
}
