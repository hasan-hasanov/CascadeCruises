using Adapter.EF.Context;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Queries.GetShipInformation
{
    public class GetShipInformationQueryHandler : IQueryHandler<GetShipInformationQuery, IList<Ship>>
    {
        private readonly CascadeCruisesContext _context;

        public GetShipInformationQueryHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task<IList<Ship>> HandleAsync(GetShipInformationQuery query, CancellationToken cancellationToken)
        {
            return await _context.Ships
                .Include(x => x.Cabins)
                .ThenInclude(x => x.CabinClass)
                .ToListAsync(cancellationToken);
        }
    }
}
