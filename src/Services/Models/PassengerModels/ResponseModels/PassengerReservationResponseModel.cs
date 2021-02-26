using Core.Entities;
using Services.Models.CabinModels.ResponseModels;
using System;

namespace Services.Models.PassengerModels.ResponseModels
{
    public class PassengerReservationResponseModel
    {
        public PassengerReservationResponseModel(PassengerReservation passengerReservation)
        {
            Id = passengerReservation.Id;
            PassengerId = passengerReservation.PassengerId;
            CabinId = passengerReservation.CabinId;
            CruiseId = passengerReservation.CruiseId;
            TravelAgentId = passengerReservation.TravelAgentId;
            Price = passengerReservation.Price;
            Date = passengerReservation.Date;
            CabinModel = new CabinResponseModel(passengerReservation.Cabin);
        }

        public int Id { get; }

        public int PassengerId { get; }

        public int CabinId { get; }

        public int CruiseId { get; }

        public int TravelAgentId { get; }

        public decimal Price { get; }

        public DateTime Date { get; }

        public CabinResponseModel CabinModel { get; }
    }
}
