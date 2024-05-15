using AutoMapper;
using NativApps.Products.Core.Models;
using ProductManagementAPI.Dtos;

namespace ProductManagementAPI.AutoMappings;

/// <summary>
/// Perfil de AutoMapper para mapear entre DTOs de usuario y entidades relacionadas.
/// </summary>
public class UserProfile : Profile
{
    /// <summary>
    /// Constructor del perfil de AutoMapper para usuarios.
    /// </summary>
    public UserProfile()
    {
        // Mapea el DTO de inicio de sesión de usuario a la entidad de usuario, con el nombre de usuario mapeado al UserId
        CreateMap<UserLoginDto, User>()
            .ForMember(d => d.UserId, o => o.MapFrom(src => src.UserName));

        // Mapea la entidad de usuario a la respuesta DTO de usuario, con el nombre de usuario mapeado al UserName y el rol mapeado al nombre del rol
        CreateMap<User, UserResponseDto>()
            .ForMember(d => d.UserName, o => o.MapFrom(src => src.UserId))
            .ForMember(d => d.Role, o => o.MapFrom(src => src.Role.Name));
    }
}