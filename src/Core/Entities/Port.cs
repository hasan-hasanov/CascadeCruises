using System.Collections.Generic;

namespace Core.Entities
{
    public class Port
    {
        public int Id { get; set; }

        public string City { get; set; }

        public ICollection<CruisePortStop> CruisePortStops { get; set; }
    }
}
