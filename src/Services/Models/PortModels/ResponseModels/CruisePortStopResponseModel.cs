using Core.Entities;
using System;

namespace Services.Models.PortModels.ResponseModels
{
    public class CruisePortStopResponseModel
    {
        public CruisePortStopResponseModel(CruisePortStop cruisePortStop)
        {
            Id = cruisePortStop.Id;
            ArrivalDate = cruisePortStop.ArrivalDate;
            DepartureDate = cruisePortStop.DepartureDate;
            Port = new PortsResponseModel(cruisePortStop.Port);
        }

        public int Id { get; }

        public DateTime ArrivalDate { get; }

        public DateTime DepartureDate { get; }

        public PortsResponseModel Port { get; }
    }
}
