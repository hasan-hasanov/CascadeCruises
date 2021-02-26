using Adapter.EF.Context;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Queries.GetPassengerReservation
{
    public class GetPassengerReservationQueryHandler : IQueryHandler<GetPassengerReservationQuery, IList<PassengerReservation>>
    {
        private readonly CascadeCruisesContext _context;

        public GetPassengerReservationQueryHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task<IList<PassengerReservation>> HandleAsync(GetPassengerReservationQuery query, CancellationToken cancellationToken)
        {
            return await _context.PassengerReservations
                .Include(x => x.Cruise)
                .Include(x => x.Passenger)
                .Include(x => x.Cabin)
                .Where(x => x.CruiseId == query.CruiseId)
                .ToListAsync(cancellationToken);
        }
    }
}
