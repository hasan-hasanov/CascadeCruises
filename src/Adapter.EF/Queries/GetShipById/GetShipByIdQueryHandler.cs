using Adapter.EF.Context;
using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Queries.GetShipById
{
    public class GetShipByIdQueryHandler : IQueryHandler<GetShipByIdQuery, Ship>
    {
        private readonly CascadeCruisesContext _context;

        public GetShipByIdQueryHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task<Ship> HandleAsync(GetShipByIdQuery query, CancellationToken cancellationToken)
        {
            Ship ship = await _context.Ships
               .Include(x => x.Cabins)
               .ThenInclude(x => x.CabinClass)
               .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

            if (ship == null) throw new NotFoundException();

            return ship;
        }
    }
}
