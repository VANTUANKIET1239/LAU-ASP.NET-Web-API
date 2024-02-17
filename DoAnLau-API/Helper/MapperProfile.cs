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
            CreateMap<XaPhuong, WardDTO>();
            CreateMap<WardDTO, XaPhuong>();
            CreateMap<QuanHuyen, DistrictDTO>();
            CreateMap<DistrictDTO, QuanHuyen>();

            CreateMap<TinhThanhPho, CityDTO>();
            CreateMap<CityDTO, TinhThanhPho>();

            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();

            CreateMap<Reservation, ReservationDTO>()
                .ForMember(dest => dest.branchId, opt => opt.MapFrom(src => src.branch.branch_Id))
                .ForMember(dest => dest.branchName, opt => opt.MapFrom(src => src.branch.branchName))
                .ForMember(dest => dest.customerSizeId, opt => opt.MapFrom(src => src.customerSize.customerSize_Id))
                .ForMember(dest => dest.customerSize, opt => opt.MapFrom(src => src.customerSize.size))
                .ForMember(dest => dest.time, opt => opt.MapFrom(src => src.reservationTime.time));
            CreateMap<ReservationDTO, Reservation>();

            CreateMap<Branch, BranchDTO>();
            CreateMap<BranchDTO, Branch>();

            CreateMap<Promotion, PromotionDTO>();
            CreateMap<PromotionDTO, Promotion>() 
                .ForMember(dest => dest.promotionDetails, opt => opt.Ignore()); 

            CreateMap<PromotionDetail, PromotionDetailDTO>();
            CreateMap<PromotionDetailDTO, PromotionDetail>();


            CreateMap<ApplicationUser, UserDTO>()
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.Id));
            CreateMap<MenuCategory, MenuCategoryDTO>();
            CreateMap<MenuCategoryDTO, MenuCategory>();
        }
    }
}
