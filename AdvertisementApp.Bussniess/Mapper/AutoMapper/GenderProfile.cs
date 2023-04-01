using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;

namespace AdvertisementApp.Bussniess.Mapper.AutoMapper
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderUpdateDto>().ReverseMap();
            CreateMap<Gender, GenderListDto>().ReverseMap();
            CreateMap<Gender, GenderCreateDto>().ReverseMap();
        }
    }
}
