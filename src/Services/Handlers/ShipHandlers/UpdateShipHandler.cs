using Adapter.EF.Commands.UpdateShip;
using Core.Commands;
using Core.Entities;
using MediatR;
using Services.Models.ShipModels.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.ShipHandlers
{
    public class UpdateShipHandler : AsyncRequestHandler<ShipModifyRequestModel>
    {
        private readonly ICommandHandler<UpdateShipCommand> _updateShipCommandHandler;

        public UpdateShipHandler(ICommandHandler<UpdateShipCommand> updateShipCommandHandler)
        {
            _updateShipCommandHandler = updateShipCommandHandler;
        }

        protected override async Task Handle(ShipModifyRequestModel request, CancellationToken cancellationToken)
        {
            Ship ship = request.ToShip();
            await _updateShipCommandHandler.Handle(new UpdateShipCommand(ship), cancellationToken);
        }
    }
}
