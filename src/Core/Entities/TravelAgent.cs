using System.Collections.Generic;

namespace Core.Entities
{
    public class TravelAgent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PIN { get; set; }

        public string Phone { get; set; }

        public string Agency { get; set; }

        public ICollection<CruiseReservation> CruiseReservations { get; set; }

        public ICollection<PassengerReservation> PassengerReservations { get; set; }
    }
}
