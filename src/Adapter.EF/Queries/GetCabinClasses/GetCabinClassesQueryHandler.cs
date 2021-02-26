using Adapter.EF.Context;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Queries.GetCabinClasses
{
    public class GetCabinClassesQueryHandler : IQueryHandler<GetCabinClassesQuery, IList<CabinClass>>
    {
        private readonly CascadeCruisesContext _context;

        public GetCabinClassesQueryHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task<IList<CabinClass>> HandleAsync(GetCabinClassesQuery query, CancellationToken cancellationToken)
        {
            return await _context.CabinClasses
               .Include(x => x.Cabins)
               .ToListAsync(cancellationToken);
        }
    }
}
