using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;

namespace AdvertisementApp.Bussniess.Interfaces
{
    public interface IGenderService : IService<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>
    {
    }
}
