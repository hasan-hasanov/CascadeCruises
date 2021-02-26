using Adapter.EF.Context;
using Common.Exceptions;
using Core.Commands;
using Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Commands.DeleteShip
{
    public class DeleteShipCommandHandler : ICommandHandler<DeleteShipCommand>
    {
        private readonly CascadeCruisesContext _context;

        public DeleteShipCommandHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteShipCommand command, CancellationToken cancellationToken)
        {
            Ship ship = _context.Ships.FirstOrDefault(x => x.Id == command.Id);

            if (ship == null) throw new NotFoundException();

            _context.Remove(ship);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
