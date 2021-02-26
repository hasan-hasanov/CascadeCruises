using Adapter.EF.Context;
using Core.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Commands.InsertCruise
{
    public class InsertCruiseCommandHandler : ICommandHandler<InsertCruiseCommand>
    {
        private readonly CascadeCruisesContext _context;

        public InsertCruiseCommandHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task Handle(InsertCruiseCommand command, CancellationToken cancellationToken)
        {
            await _context.Cruises.AddAsync(command.Cruise, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
