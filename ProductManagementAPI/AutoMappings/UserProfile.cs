using AutoMapper;
using Microsoft.Build.Framework;
using NativApps.Products.Core.Models;
using ProductManagementAPI.Dtos;

namespace ProductManagementAPI.AutoMappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserLoginDto, User>()
        .ForMember(d => d.UserId, o => o.MapFrom(src => src.UserName));

        CreateMap<User, UserResponseDto>()
            .ForMember(d => d.UserName, o => o.MapFrom(src => src.UserId))
            .ForMember(d => d.Role, o => o.MapFrom(src => src.Role.Name));
    }
}


