using Adapter.EF.Context;
using Common.Exceptions;
using Core.Commands;
using Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Commands.DeleteCruise
{
    public class DeleteCruiseCommandHandler : ICommandHandler<DeleteCruiseCommand>
    {
        private readonly CascadeCruisesContext _context;

        public DeleteCruiseCommandHandler(CascadeCruisesContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCruiseCommand command, CancellationToken cancellationToken)
        {
            Cruise cruise = _context.Cruises.FirstOrDefault(x => x.Id == command.Id);

            if (cruise == null) throw new NotFoundException();

            _context.Remove(cruise);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
