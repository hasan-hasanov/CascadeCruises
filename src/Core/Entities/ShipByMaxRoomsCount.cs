using System;

namespace Core.Entities
{
    public class ShipByMaxRoomsCount
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Registry { get; set; }

        public DateTime CreateDate { get; set; }

        public int RoomsCount { get; set; }

        public decimal FirstClassRoomPrice { get; set; }

        public decimal SecondClassRoomPrice { get; set; }

        public decimal ThirdClassRoomPrice { get; set; }
    }
}
