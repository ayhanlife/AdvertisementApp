using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Bussniess.ValidationRules.FluentValidations.AppUser
{
    public class AppUserUpdateDtoValidator : AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
        }
    }
}
