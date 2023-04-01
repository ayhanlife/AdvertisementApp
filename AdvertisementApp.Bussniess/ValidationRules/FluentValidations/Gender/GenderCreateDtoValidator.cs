using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Bussniess.ValidationRules.FluentValidations.Gender
{
    public class GenderCreateDtoValidator : AbstractValidator<GenderCreateDto>
    {
        public GenderCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
