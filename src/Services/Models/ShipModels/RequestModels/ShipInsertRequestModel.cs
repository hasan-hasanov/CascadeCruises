using Core.Entities;
using MediatR;
using Services.Models.CabinModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Models.ShipModels.RequestModels
{
    public class ShipInsertRequestModel : IRequest
    {
        public string Name { get; }

        public string Registry { get; }

        public IList<CabinInsertRequestModel> Cabins { get; }

        public Ship ToShip()
        {
            return new Ship()
            {
                Name = Name,
                Registry = Registry,
                CreateDate = DateTime.Now,
                Cabins = Cabins.Select(c => c.ToCabin()).ToList()
            };
        }
    }
}
