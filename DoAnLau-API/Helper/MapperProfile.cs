using AutoMapper;
using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace DoAnLau_API.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Menu, MenuDTO>()
                 .ForMember(dest => dest.MenuCategoryId, opt => opt.MapFrom(src => src.menuCategory.menuCategory_Id))
                  .ForMember(dest => dest.MenuCategoryName, opt => opt.MapFrom(src => src.menuCategory.categoryName))
                 ;
            CreateMap<MenuDTO, Menu>();
            CreateMap<ApplicationUser, UserDTO>();
            CreateMap<MenuCategory, MenuCategoryDTO>();
            CreateMap<MenuCategoryDTO, MenuCategory>();
        }
    }
}
