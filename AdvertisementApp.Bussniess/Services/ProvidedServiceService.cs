﻿using AdvertisementApp.Bussniess.Interfaces;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;

namespace AdvertisementApp.Bussniess.Services
{
    public class ProvidedServiceService : Service<ProvidedServiceCreateDto,ProvidedServiceUpdateDto,ProvidedServiceListDto,ProvidedService>,IProvidedServiceService
    {
        public ProvidedServiceService(IMapper mapper, IValidator<ProvidedServiceCreateDto> createDtoValidator,IValidator<ProvidedServiceUpdateDto> updateDtoValidator,IUow uow) : base(mapper,createDtoValidator,updateDtoValidator,uow)
        {
        }

    }
}
