using Adapter.EF.Context;
using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Queries.GetCruiseById
{
    public class GetCruiseByIdQueryHandler : IQueryHandler<GetCruiseByIdQuery, Cruise>
    {
        private readonly CascadeCruisesContext _context;

        public GetCruiseByIdQueryHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task<Cruise> HandleAsync(GetCruiseByIdQuery query, CancellationToken cancellationToken)
        {
            var cruise = await _context.Cruises
             .Include(x => x.Ship)
             .ThenInclude(x => x.Cabins)
             .ThenInclude(x => x.CabinClass)
             .Include(x => x.PassengerReservations)
             .Include(x => x.CruisePortStops)
             .ThenInclude(x => x.Port)
             .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

            if (cruise == null) throw new NotFoundException();

            return cruise;
        }
    }
}
