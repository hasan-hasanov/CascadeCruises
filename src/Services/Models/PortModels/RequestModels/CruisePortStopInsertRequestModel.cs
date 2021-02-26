using Core.Entities;
using System;

namespace Services.Models.PortModels.RequestModels
{
    public class CruisePortStopInsertRequestModel
    {
        public DateTime ArrivalDate { get; }

        public DateTime DepartureDate { get; }

        public int PortId { get; }

        public CruisePortStop ToCruisePortStop()
        {
            return new CruisePortStop()
            {
                ArrivalDate = ArrivalDate,
                DepartureDate = DepartureDate,
                PortId = PortId
            };
        }
    }
}
