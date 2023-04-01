using AdvertisementApp.Bussniess.Extensions;
using AdvertisementApp.Bussniess.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AdvertisementApp.Bussniess.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;

        public AdvertisementAppUserService(IValidator<AdvertisementAppUserCreateDto> createDtoValidator, IMapper mapper, IUow uow)
        {
            _createDtoValidator = createDtoValidator;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Response<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);

            if (result.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId &&
                x.AdvertisementId == dto.AdvertisementId);
                if (control == null)
                {
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                    await _uow.SaveChangesAsync();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }

                List<CustomValidationError> errors = new List<CustomValidationError>
                {
                    new CustomValidationError { ErrorMessage = "Daha önce bu ilana başvuru  yapılmış.",Property=""}
                };
                return new Response<AdvertisementAppUserCreateDto>(dto, errors);

            }
            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }


        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();

            var list = await query.Include(x => x.Advertisement).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus).Include(x => x.AppUser).Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();
            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }


        public async Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();
            var entity =  await query.SingleOrDefaultAsync(x => x.Id == advertisementAppUserId);
            entity.AdvertisementAppUserStatusId = (int)type;
            await _uow.SaveChangesAsync();
        }
    }
}
