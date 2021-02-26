using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Ship
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Registry { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<Cruise> Cruises { get; set; }

        public ICollection<Cabin> Cabins { get; set; }
    }
}
