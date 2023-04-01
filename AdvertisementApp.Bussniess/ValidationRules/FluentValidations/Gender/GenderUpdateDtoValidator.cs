using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Bussniess.ValidationRules.FluentValidations.Gender
{
    public class GenderUpdateDtoValidator : AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
