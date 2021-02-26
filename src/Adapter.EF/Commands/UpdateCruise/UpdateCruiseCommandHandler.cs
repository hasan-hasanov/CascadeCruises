using Adapter.EF.Context;
using Common.Exceptions;
using Core.Commands;
using Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Commands.UpdateCruise
{
    public class UpdateCruiseCommandHandler : ICommandHandler<UpdateCruiseCommand>
    {
        private readonly CascadeCruisesContext _context;

        public UpdateCruiseCommandHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCruiseCommand command, CancellationToken cancellationToken)
        {
            Cruise cruiseForUpdate = _context.Cruises.Find(command.Cruise.Id);

            if (cruiseForUpdate == null) throw new NotFoundException();

            cruiseForUpdate.Name = command.Cruise.Name;
            cruiseForUpdate.Ship = command.Cruise.Ship;
            cruiseForUpdate.CruisePortStops = command.Cruise.CruisePortStops;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
