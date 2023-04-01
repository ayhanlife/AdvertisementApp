using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;

namespace AdvertisementApp.Bussniess.Mapper.AutoMapper
{
    public class AdvertisementAppUserProfile : Profile
    {
        public AdvertisementAppUserProfile()
        {
            CreateMap<AdvertisementAppUser, AdvertisementAppUserCreateDto>().ReverseMap();
            CreateMap<AdvertisementAppUser, AdvertisementAppUserListDto>().ReverseMap();
        }
    }
}
