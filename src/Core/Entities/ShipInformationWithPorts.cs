using System;

namespace Core.Entities
{
    public class ShipInformationWithPorts
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Registry { get; set; }

        public DateTime CreateDate { get; set; }

        public int FirstClassRoomCount { get; set; }

        public int SecondClassRoomCount { get; set; }

        public int ThirdClassRoomCount { get; set; }

        public DateTime FirstStopDate { get; set; }

        public DateTime LastStopDate { get; set; }

        public string PortCity { get; set; }

        public string LastPortCity { get; set; }

        public int PassengerCount { get; set; }

    }
}
