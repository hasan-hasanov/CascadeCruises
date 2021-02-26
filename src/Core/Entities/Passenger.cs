using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Passenger
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PIN { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<PassengerReservation> PassengerReservations { get; set; }
    }
}
