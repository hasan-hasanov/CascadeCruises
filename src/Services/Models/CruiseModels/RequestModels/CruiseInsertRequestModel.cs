using Core.Entities;
using MediatR;
using Services.Models.PortModels.RequestModels;
using System.Collections.Generic;
using System.Linq;

namespace Services.Models.CruiseModels.RequestModels
{
    public class CruiseInsertRequestModel : IRequest
    {
        public string Name { get; }

        public int ShipId { get; }

        public IList<CruisePortStopInsertRequestModel> CruisePortStops { get; }

        public Cruise ToCruise()
        {
            return new Cruise()
            {
                Name = Name,
                ShipId = ShipId,
                CruisePortStops = CruisePortStops.Select(c => c.ToCruisePortStop()).ToList()
            };
        }
    }
}
