using Core.Entities;
using System;

namespace Services.Models.ReportsModel.ResponseModels
{
    public class ShipByMaxRoomsCountResponseModel
    {
        public ShipByMaxRoomsCountResponseModel(ShipByMaxRoomsCount shipByMaxRoomsCount)
        {
            Id = shipByMaxRoomsCount.Id;
            Name = shipByMaxRoomsCount.Name;
            Registry = shipByMaxRoomsCount.Registry;
            CreateDate = shipByMaxRoomsCount.CreateDate;
            RoomsCount = shipByMaxRoomsCount.RoomsCount;
            FirstClassRoomPrice = shipByMaxRoomsCount.FirstClassRoomPrice;
            SecondClassRoomPrice = shipByMaxRoomsCount.SecondClassRoomPrice;
            ThirdClassRoomPrice = shipByMaxRoomsCount.ThirdClassRoomPrice;
        }

        public int Id { get; }

        public string Name { get; }

        public string Registry { get; }

        public DateTime CreateDate { get; }

        public int RoomsCount { get; }

        public decimal FirstClassRoomPrice { get; }

        public decimal SecondClassRoomPrice { get; }

        public decimal ThirdClassRoomPrice { get; }
    }
}
