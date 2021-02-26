using Core.Entities;
using System;

namespace Services.Models.PortModels.RequestModels
{
    public class CruisePortStopModifyRequestModel
    {
        public int Id { get; }

        public DateTime ArrivalDate { get; }

        public DateTime DepartureDate { get; }

        public int PortId { get; }

        public CruisePortStop ToCruisePortStop()
        {
            return new CruisePortStop()
            {
                Id = Id,
                ArrivalDate = ArrivalDate,
                DepartureDate = DepartureDate,
                PortId = PortId
            };
        }
    }
}
