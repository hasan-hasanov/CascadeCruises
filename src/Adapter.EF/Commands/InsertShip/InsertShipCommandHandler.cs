using Adapter.EF.Context;
using Core.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Commands.InsertShip
{
    public class InsertShipCommandHandler : ICommandHandler<InsertShipCommand>
    {
        private readonly CascadeCruisesContext _context;

        public InsertShipCommandHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task Handle(InsertShipCommand command, CancellationToken cancellationToken)
        {
            await _context.Ships.AddAsync(command.Ship, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
