using Adapter.EF.Context;
using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Queries.GetPassengerAgeAboveSixty
{
    public class GetPassengersAgeAboveSixtyQueryHandler : IQueryHandler<GetPassengersAgeAboveSixtyQuery, IList<PassengerAgeAboveSixty>>
    {
        private readonly CascadeCruisesContext _context;

        public GetPassengersAgeAboveSixtyQueryHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task<IList<PassengerAgeAboveSixty>> HandleAsync(GetPassengersAgeAboveSixtyQuery query, CancellationToken cancellationToken)
        {
            Cruise cruise = _context.Cruises.Find(query.CruiseId);

            if (cruise == null) throw new NotFoundException();

            return await _context.PassengerAgeAboveSixties
                .FromSqlRaw($"[dbo].[SP_SELECT_PASSANGER_AGE_ABOVE_SIXTY] @CruiseId = {query.CruiseId}")
                .ToListAsync(cancellationToken);
        }
    }
}
