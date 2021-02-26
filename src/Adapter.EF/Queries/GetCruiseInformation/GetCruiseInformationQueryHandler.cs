using Adapter.EF.Context;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Queries.GetCruiseInformation
{
    public class GetCruiseInformationQueryHandler : IQueryHandler<GetCruiseInformationQuery, IList<Cruise>>
    {
        private readonly CascadeCruisesContext _context;

        public GetCruiseInformationQueryHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task<IList<Cruise>> HandleAsync(GetCruiseInformationQuery query, CancellationToken cancellationToken)
        {
            return await _context.Cruises
                .Include(x => x.Ship)
                .ThenInclude(x => x.Cabins)
                .ThenInclude(x => x.CabinClass)
                .Include(x => x.PassengerReservations)
                .Include(x => x.CruisePortStops)
                .ThenInclude(x => x.Port)
                .Where(x => x.CruisePortStops.OrderBy(c => c.DepartureDate).First().DepartureDate > query.CurrentDate)
                .ToListAsync(cancellationToken);
        }
    }
}
