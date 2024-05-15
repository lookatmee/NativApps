using AutoMapper;
using NativApps.Products.Core.Models;
using ProductManagementAPI.Dtos;

namespace ProductManagementAPI.AutoMappings;

/// <summary>
/// Perfil de AutoMapper para mapear entre entidades de producto y DTOs relacionados.
/// </summary>
public class ProductProfile : Profile
{
    /// <summary>
    /// Constructor del perfil de AutoMapper para productos.
    /// </summary>
    public ProductProfile()
    {
        // Mapea el DTO de producto a la entidad de producto y viceversa
        CreateMap<ProductDto, Product>().ReverseMap();

        // Mapea la entidad de producto a la respuesta DTO de producto
        CreateMap<Product, ProductResponseDto>()
            .ForMember(d => d.Category, o => o.MapFrom(src => new CategoryDto { Id = src.CategoryId, Description = src.Category.Description, Name = src.Category.Name }));
    }
}
