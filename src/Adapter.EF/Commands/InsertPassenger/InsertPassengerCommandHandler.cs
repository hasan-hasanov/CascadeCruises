using Adapter.EF.Context;
using Core.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Commands.InsertPassenger
{
    public class InsertPassengerCommandHandler : ICommandHandler<InsertPassengerCommand>
    {
        private readonly CascadeCruisesContext _context;

        public InsertPassengerCommandHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task Handle(InsertPassengerCommand command, CancellationToken cancellationToken)
        {
            await _context.Passengers.AddAsync(command.Passenger, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
