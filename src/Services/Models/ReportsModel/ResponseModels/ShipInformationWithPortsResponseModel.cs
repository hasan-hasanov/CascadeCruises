using Core.Entities;
using System;

namespace Services.Models.ReportsModel.ResponseModels
{
    public class ShipInformationWithPortsResponseModel
    {
        public ShipInformationWithPortsResponseModel(ShipInformationWithPorts shipInformationWithPorts)
        {
            Id = shipInformationWithPorts.Id;
            Name = shipInformationWithPorts.Name;
            Registry = shipInformationWithPorts.Registry;
            CreateDate = shipInformationWithPorts.CreateDate;
            FirstClassRoomCount = shipInformationWithPorts.FirstClassRoomCount;
            SecondClassRoomCount = shipInformationWithPorts.SecondClassRoomCount;
            ThirdClassRoomCount = shipInformationWithPorts.ThirdClassRoomCount;
            FirstStopDate = shipInformationWithPorts.FirstStopDate;
            LastStopDate = shipInformationWithPorts.LastStopDate;
            PortCity = shipInformationWithPorts.PortCity;
            LastPortCity = shipInformationWithPorts.LastPortCity;
            PassengerCount = shipInformationWithPorts.PassengerCount;
        }

        public int Id { get; }

        public string Name { get; }

        public string Registry { get; }

        public DateTime CreateDate { get; }

        public int FirstClassRoomCount { get; }

        public int SecondClassRoomCount { get; }

        public int ThirdClassRoomCount { get; }

        public DateTime FirstStopDate { get; }

        public DateTime LastStopDate { get; }

        public string PortCity { get; }

        public string LastPortCity { get; }

        public int PassengerCount { get; }
    }
}
