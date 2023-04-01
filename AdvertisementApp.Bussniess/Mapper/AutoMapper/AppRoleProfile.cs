using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;

namespace AdvertisementApp.Bussniess.Mapper.AutoMapper
{
    public class AppRoleProfile : Profile
    {
        public AppRoleProfile()
        {
            CreateMap<AppRole, AppRoleListDto>().ReverseMap();
        }
    }
}
