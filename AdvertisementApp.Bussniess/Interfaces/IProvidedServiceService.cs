using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;

namespace AdvertisementApp.Bussniess.Interfaces
{
    public interface IProvidedServiceService : IService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>
    {
    }
}
