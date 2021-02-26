using Core.Entities;
using Core.Queries;
using System.Collections.Generic;

namespace Adapter.EF.Queries.GetPassengerAgeAboveSixty
{
    public class GetPassengersAgeAboveSixtyQuery : IQuery<IList<PassengerAgeAboveSixty>>
    {
        public GetPassengersAgeAboveSixtyQuery(int cruiseId)
        {
            CruiseId = cruiseId;
        }

        public int CruiseId { get; }
    }
}
