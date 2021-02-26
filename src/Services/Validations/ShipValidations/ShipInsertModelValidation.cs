using Common.Exceptions;
using Core.Validation;
using Services.Models.ShipModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Validations.ShipValidations
{
    public class ShipInsertRequestModelValidation : IValidation<ShipInsertRequestModel>
    {
        public void Validate(ShipInsertRequestModel model)
        {
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Name))
                errorMessages.Add($"{nameof(model.Name)} is required");

            if (model.Cabins == null)
                errorMessages.Add($"{nameof(model.Cabins)} is required");

            if (errorMessages.Any())
            {
                throw new BadRequestException(string.Join(Environment.NewLine, errorMessages));
            }
        }
    }
}
