using FluentValidation.Results;
using FSE.AdvertisementApp.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this
            ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new List<CustomValidationError>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new CustomValidationError()
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }) ;
            }
            return errors;
        }
    }
}
