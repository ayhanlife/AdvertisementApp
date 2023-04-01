using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;

namespace AdvertisementApp.Bussniess.Mapper.AutoMapper
{
    public class MilitaryStatusProfile : Profile
    {

        public MilitaryStatusProfile()
        {
            CreateMap<MilitaryStatus, MilitaryStatusListDto>().ReverseMap();
        }
    }
}
