using Adapter.EF.Context;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Queries.GetShipInformationWithPorts
{
    public class GetShipInformationWithPortsQueryHandler : IQueryHandler<GetShipInformationWithPortsQuery, IList<ShipInformationWithPorts>>
    {
        private readonly CascadeCruisesContext _context;

        public GetShipInformationWithPortsQueryHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task<IList<ShipInformationWithPorts>> HandleAsync(GetShipInformationWithPortsQuery query, CancellationToken cancellationToken)
        {
            return await _context.ShipsInformationWithPorts
                .FromSqlRaw("[dbo].[SP_SELECT_SHIPS_INFORMATION_WITH_PORTS]")
                .ToListAsync(cancellationToken);
        }
    }
}
