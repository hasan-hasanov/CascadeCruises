using Common.Exceptions;
using Core.Validation;
using Services.Models.PassengerModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Validations.PassengerValidations
{
    public class PassengerReservationResponseModelValidation : IValidation<PassengerReservationResponseModel>
    {
        public void Validate(PassengerReservationResponseModel model)
        {
            List<string> errorMessages = new List<string>();

            if (model.CabinId == 0)
                errorMessages.Add($"{nameof(model.CabinId)} is required");

            if (model.PassengerId == 0)
                errorMessages.Add($"{nameof(model.PassengerId)} is required");

            if (model.CruiseId == 0)
                errorMessages.Add($"{nameof(model.CruiseId)} is required");

            if (model.TravelAgentId == 0)
                errorMessages.Add($"{nameof(model.TravelAgentId)} is required");

            if (model.CabinModel == null)
                errorMessages.Add($"{nameof(model.CabinModel)} is required");

            if (model.CabinModel.CabinClass == null)
                errorMessages.Add($"{nameof(model.CabinModel.CabinClass)} is required");

            if (errorMessages.Any())
            {
                throw new BadRequestException(string.Join(Environment.NewLine, errorMessages));
            }
        }
    }
}
