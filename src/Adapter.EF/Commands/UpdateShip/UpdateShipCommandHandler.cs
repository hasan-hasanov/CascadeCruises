using Adapter.EF.Context;
using Common.Exceptions;
using Core.Commands;
using Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Commands.UpdateShip
{
    public class UpdateShipCommandHandler : ICommandHandler<UpdateShipCommand>
    {
        private readonly CascadeCruisesContext _context;

        public UpdateShipCommandHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateShipCommand command, CancellationToken cancellationToken)
        {
            Ship shipForUpdate = _context.Ships.Find(command.Ship.Id);

            if (shipForUpdate == null) throw new NotFoundException();

            shipForUpdate.Name = command.Ship.Name;
            shipForUpdate.Registry = command.Ship.Registry;
            shipForUpdate.Cabins = command.Ship.Cabins;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
