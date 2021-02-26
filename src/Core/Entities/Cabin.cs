using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
   public class Cabin
   {
      public int Id { get; set; }

      public int MaxNumberOfPeople { get; set; }

      public int CurrentNumberOfPeople => this.PassengerReservations == null || !this.PassengerReservations.Any() ? 0 : this.PassengerReservations.Count;

      public int ShipId { get; set; }

      public int ClassId { get; set; }

      public int Number { get; set; }

      public decimal MaxPrice { get; set; }

      public Ship Ship { get; set; }

      public CabinClass CabinClass { get; set; }

      public ICollection<PassengerReservation> PassengerReservations { get; set; }
   }
}
