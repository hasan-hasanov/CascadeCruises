using Core.Entities;
using Core.Queries;
using System.Collections.Generic;

namespace Adapter.EF.Queries.GetPassengerReservation
{
    public class GetPassengerReservationQuery : IQuery<IList<PassengerReservation>>
    {
        public GetPassengerReservationQuery(int cruiseId)
        {
            CruiseId = cruiseId;
        }

        public int CruiseId { get; }
    }
}
