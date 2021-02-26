using Adapter.EF.Context;
using Common.Exceptions;
using Core.Commands;
using Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Commands.DeletePassenger
{
    public class DeletePassengerCommandHandler : ICommandHandler<DeletePassengerCommand>
    {
        private readonly CascadeCruisesContext _context;

        public DeletePassengerCommandHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task Handle(DeletePassengerCommand command, CancellationToken cancellationToken)
        {
            Passenger passenger = _context.Passengers.FirstOrDefault(x => x.Id == command.Id);

            if (passenger == null) throw new NotFoundException();

            _context.Remove(passenger);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
