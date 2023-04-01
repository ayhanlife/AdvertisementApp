using AdvertisementApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Bussniess.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this FluentValidation.Results.ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage =error.ErrorMessage,
                    Property = error.PropertyName,
                });
            }
            return errors;

        }
    }
}
