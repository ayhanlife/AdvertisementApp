using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;

namespace AdvertisementApp.Bussniess.Mapper.AutoMapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();
            CreateMap<AppUser, AppUserCreateDto>().ReverseMap();
        }
    }
}
