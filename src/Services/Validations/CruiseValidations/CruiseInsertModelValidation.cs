using Common.Exceptions;
using Core.Validation;
using Services.Models.CruiseModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Validations.CruiseValidations
{
    public class InsertCruiseRequestModelValidation : IValidation<CruiseInsertRequestModel>
    {
        public void Validate(CruiseInsertRequestModel model)
        {
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Name))
                errorMessages.Add($"{nameof(model.Name)} is required");

            if (model.ShipId == 0)
                errorMessages.Add($"{nameof(model.ShipId)} is required");

            if (model.CruisePortStops == null || !model.CruisePortStops.Any())
                errorMessages.Add($"{nameof(model.CruisePortStops)} is required");

            if (model.CruisePortStops != null && model.CruisePortStops.Any(d => d.ArrivalDate > d.DepartureDate))
                errorMessages.Add($"Departure date cannot be less than arrival date");

            if (errorMessages.Any())
            {
                throw new BadRequestException(string.Join(Environment.NewLine, errorMessages));
            }
        }
    }
}
