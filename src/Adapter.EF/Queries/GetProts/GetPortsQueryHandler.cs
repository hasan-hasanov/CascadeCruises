using Adapter.EF.Context;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Queries.GetProts
{
    public class GetPortsQueryHandler : IQueryHandler<GetPortsQuery, IList<Port>>
    {
        private readonly CascadeCruisesContext _context;

        public GetPortsQueryHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task<IList<Port>> HandleAsync(GetPortsQuery query, CancellationToken cancellationToken)
        {
            return await _context.Ports
                .Include(x => x.CruisePortStops)
                .ToListAsync(cancellationToken);
        }
    }
}
