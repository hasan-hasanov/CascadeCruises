using Adapter.EF.Commands.DeleteShip;
using Core.Commands;
using MediatR;
using Services.Models.ShipModels.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.ShipHandlers
{
    public class DeleteShipHandler : AsyncRequestHandler<DeleteShipRequestModel>
    {
        private readonly ICommandHandler<DeleteShipCommand> _deleteShipCommandHandler;

        public DeleteShipHandler(ICommandHandler<DeleteShipCommand> deleteShipCommandHandler)
        {
            _deleteShipCommandHandler = deleteShipCommandHandler;
        }

        protected override async Task Handle(DeleteShipRequestModel request, CancellationToken cancellationToken)
        {
            await _deleteShipCommandHandler.Handle(new DeleteShipCommand(request.Id), cancellationToken);
        }
    }
}
