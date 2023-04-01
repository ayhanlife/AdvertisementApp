using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Bussniess.Mapper.AutoMapper
{
    public class AdvertisementAppUserStatusProfile : Profile
    {
        public AdvertisementAppUserStatusProfile()
        {


            CreateMap<AdvertisementAppUserStatus,AdversisementAppUserStatusListDto>().ReverseMap();
        }
    }
}
