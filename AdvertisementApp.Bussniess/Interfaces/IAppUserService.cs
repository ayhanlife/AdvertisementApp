using AdvertisementApp.Common;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;

namespace AdvertisementApp.Bussniess.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId);
        Task<IResponse<AppUserListDto>> CheckUser(AppUserLoginDto dto);
        Task<IResponse<List<AppRoleListDto>>> GetRoles(int userId);
    }
}
