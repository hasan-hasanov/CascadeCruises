using Core.Entities;
using Services.Models.PassengerModels.ResponseModels;
using Services.Models.PortModels.ResponseModels;
using Services.Models.ShipModels.ResponseModels;
using System.Collections.Generic;
using System.Linq;

namespace Services.Models.CruiseModels.ResponseModels
{
    public class CruiseResponseModel
    {
        public CruiseResponseModel(Cruise cruise)
        {
            Id = cruise.Id;
            Name = cruise.Name;
            Ship = new ShipResponseModel(cruise.Ship);
            CruisePortStops = cruise.CruisePortStops.Select(x => new CruisePortStopResponseModel(x)).ToList();
            PassengerReservations = cruise.PassengerReservations?.Select(x => new PassengerReservationResponseModel(x)).ToList();
        }

        public int Id { get; }

        public string Name { get; }

        public ShipResponseModel Ship { get; }

        public IList<CruisePortStopResponseModel> CruisePortStops { get; }

        public IList<PassengerReservationResponseModel> PassengerReservations { get; }
    }
}
