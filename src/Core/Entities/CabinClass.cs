using System.Collections.Generic;

namespace Core.Entities
{
    public class CabinClass
    {
        public int Id { get; set; }

        public string Class { get; set; }

        public ICollection<Cabin> Cabins { get; set; }
    }
}
