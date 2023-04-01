using AdvertisementApp.Common;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos;

namespace AdvertisementApp.Bussniess.Interfaces
{
    public interface IAdvertisementAppUserService
    {

        Task<Response<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
        Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type);
        Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type);

    }
}
