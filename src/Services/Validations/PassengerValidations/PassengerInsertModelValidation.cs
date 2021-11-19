using Common.Exceptions;
using Core.Validation;
using Services.Models.PassengerModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Validations.PassengerValidations
{
    public class PassengerInsertRequestModelValidation : IValidation<PassengerInsertRequestModel>
    {
        public void Validate(PassengerInsertRequestModel model)
        {
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Name))
                errorMessages.Add($"{nameof(model.Name)} is required");

            if (string.IsNullOrWhiteSpace(model.LastName))
                errorMessages.Add($"{nameof(model.LastName)} is required");

            if (string.IsNullOrWhiteSpace(model.PIN))
                errorMessages.Add($"{nameof(model.PIN)} is required");

            if (model.DateOfBirth == DateTime.MinValue)
                errorMessages.Add($"{nameof(model.DateOfBirth)} is required");

            if (errorMessages.Any())
            {
                throw new BadRequestException(string.Join(Environment.NewLine, errorMessages));
            }
        }
    }
}
