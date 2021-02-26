using Core.Entities;
using MediatR;
using Services.Models.CabinModels.RequestModels;
using System.Collections.Generic;
using System.Linq;

namespace Services.Models.ShipModels.RequestModels
{
    public class ShipModifyRequestModel : IRequest
    {
        public int Id { get; }

        public string Name { get; }

        public string Registry { get; }

        public IList<CabinModifyRequestModel> Cabins { get; }

        public Ship ToShip()
        {
            return new Ship()
            {
                Id = Id,
                Name = Name,
                Registry = Registry,
                Cabins = Cabins.Select(c => c.ToCabin()).ToList()
            };
        }
    }
}
