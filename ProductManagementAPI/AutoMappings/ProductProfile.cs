using AutoMapper;
using NativApps.Products.Core.Models;
using ProductManagementAPI.Dtos;

namespace ProductManagementAPI.AutoMappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<Product, ProductResponseDto>()
            .ForMember(d => d.Category, o => o.MapFrom(src => new CategoryDto { Id = src.CategoryId, Description = src.Category.Description, Name = src.Category.Name }));
    }
}
