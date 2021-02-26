using Adapter.EF.Context;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Queries.GetShipByMaxRoomsCount
{
    public class GetShipByMaxRoomsCountQueryHandler : IQueryHandler<GetShipByMaxRoomsCountQuery, IList<ShipByMaxRoomsCount>>
    {
        private readonly CascadeCruisesContext _context;

        public GetShipByMaxRoomsCountQueryHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task<IList<ShipByMaxRoomsCount>> HandleAsync(GetShipByMaxRoomsCountQuery query, CancellationToken cancellationToken)
        {
            return await _context.ShipsByMaxRoomsCounts
                .FromSqlRaw("[dbo].[SP_SELECT_SHIPS_BY_MAX_ROOMS_COUNT]")
                .ToListAsync(cancellationToken);
        }
    }
}
