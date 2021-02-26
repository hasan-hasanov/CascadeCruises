using System;

namespace Core.Entities
{
    public class PassengerReservation
    {
        public int Id { get; set; }

        public int PassengerId { get; set; }

        public decimal Price { get; set; }

        public int CabinId { get; set; }

        public DateTime Date { get; set; }

        public int CruiseId { get; set; }

        public int TravelAgentId { get; set; }

        public Cabin Cabin { get; set; }

        public Passenger Passenger { get; set; }

        public Cruise Cruise { get; set; }

        public TravelAgent TravelAgent { get; set; }
    }
}
