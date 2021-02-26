using Adapter.EF.Context;
using Common.Exceptions;
using Core.Commands;
using Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Commands.UpdatePassenger
{
    public class UpdatePassengerCommandHandler : ICommandHandler<UpdatePassengerCommand>
    {
        private readonly CascadeCruisesContext _context;

        public UpdatePassengerCommandHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdatePassengerCommand command, CancellationToken cancellationToken)
        {
            Passenger passengerForUpdate = _context.Passengers.Find(command.Passenger.Id);

            if (passengerForUpdate == null) throw new NotFoundException();

            passengerForUpdate.PIN = command.Passenger.PIN;
            passengerForUpdate.Name = command.Passenger.Name;
            passengerForUpdate.LastName = command.Passenger.LastName;
            passengerForUpdate.Address = command.Passenger.Address;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
