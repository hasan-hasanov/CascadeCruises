using System;

namespace Core.Entities
{
    public class CruisePortStop
    {
        public int Id { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public int CruiseId { get; set; }

        public int PortId { get; set; }

        public Port Port { get; set; }

        public Cruise Cruise { get; set; }
    }
}
