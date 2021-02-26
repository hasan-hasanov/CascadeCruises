using System.Collections.Generic;

namespace Core.Entities
{
    public class Cruise
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ShipId { get; set; }

        public Ship Ship { get; set; }

        public ICollection<CruisePortStop> CruisePortStops { get; set; }

        public ICollection<CruiseReservation> CruiseReservations { get; set; }

        public ICollection<PassengerReservation> PassengerReservations { get; set; }
    }
}
