using AutoMapper;
using Refah.Application.Dtos.Order_Dtos;
using Refah.Application.Dtos.Product_Dtos;
using Refah.Application.Dtos.ProductCategory_Dtos;
using Refah.Application.Dtos.User_Dtos;
using Refah.Domain.Entities;

namespace Refah.Application.Profiles
{
    public class Auto_Map : Profile
    {
        #region [-ctor-]
        public Auto_Map()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<CustomUser, UserDto>().ReverseMap();
        } 
        #endregion
    }
}
