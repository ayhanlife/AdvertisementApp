using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Bussniess.ValidationRules.FluentValidations.AppUser
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x=>x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifre boş olamaz");
        }
    }
}
