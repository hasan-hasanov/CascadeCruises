using Core.Entities;
using MediatR;
using Services.Models.PortModels.RequestModels;
using System.Collections.Generic;
using System.Linq;

namespace Services.Models.CruiseModels.RequestModels
{
    public class CruiseModfiyRequestModel : IRequest
    {
        public int Id { get; }

        public string Name { get; }

        public int ShipId { get; }

        public IList<CruisePortStopModifyRequestModel> CruisePortStops { get; }

        public Cruise ToCruise()
        {
            return new Cruise()
            {
                Id = Id,
                Name = Name,
                ShipId = ShipId,
                CruisePortStops = CruisePortStops.Select(c => c.ToCruisePortStop()).ToList()
            };
        }
    }
}
