using AdvertisementApp.Common;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;

namespace AdvertisementApp.Bussniess.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}
