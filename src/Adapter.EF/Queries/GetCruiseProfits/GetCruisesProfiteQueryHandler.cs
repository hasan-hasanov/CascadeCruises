using Adapter.EF.Context;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Queries.GetCruiseProfits
{
    public class GetCruisesProfiteQueryHandler : IQueryHandler<GetCruisesProfitsQuery, IList<CruiseProfit>>
    {
        private readonly CascadeCruisesContext _context;

        public GetCruisesProfiteQueryHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task<IList<CruiseProfit>> HandleAsync(GetCruisesProfitsQuery query, CancellationToken cancellationToken)
        {
            return await _context.CruisesProfits
                .FromSqlRaw("[dbo].[SP_SELECT_CRUISE_PROFITS]")
               .ToListAsync(cancellationToken);
        }
    }
}
