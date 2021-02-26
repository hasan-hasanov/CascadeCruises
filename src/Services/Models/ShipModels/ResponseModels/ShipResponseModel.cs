using Core.Entities;
using Services.Models.CabinModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Models.ShipModels.ResponseModels
{
    public class ShipResponseModel
    {
        public ShipResponseModel(Ship ship)
        {
            Id = ship.Id;
            Name = ship.Name;
            Registry = ship.Registry;
            CreateDate = ship.CreateDate;
            Cabins = ship.Cabins
                .Select(c => new CabinResponseModel(c))
                .ToList();
        }

        public int Id { get; }

        public string Name { get; }

        public string Registry { get; }

        public DateTime CreateDate { get; }

        public IList<CabinResponseModel> Cabins { get; }
    }
}
