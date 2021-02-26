using Adapter.EF.Commands.InsertShip;
using Core.Commands;
using Core.Entities;
using Core.Validation;
using MediatR;
using Services.Models.ShipModels.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.ShipHandlers
{
    public class InsertShipHandler : AsyncRequestHandler<ShipInsertRequestModel>
    {
        private readonly ICommandHandler<InsertShipCommand> _insertShipCommandHandler;
        private readonly IValidation<ShipInsertRequestModel> _shipInsertModelValidation;

        public InsertShipHandler(
            ICommandHandler<InsertShipCommand> insertShipCommandHandler,
            IValidation<ShipInsertRequestModel> shipInsertModelValidation)
        {
            _insertShipCommandHandler = insertShipCommandHandler;
            _shipInsertModelValidation = shipInsertModelValidation;
        }

        protected override async Task Handle(ShipInsertRequestModel request, CancellationToken cancellationToken)
        {
            _shipInsertModelValidation.Validate(request);

            Ship ship = request.ToShip();
            await _insertShipCommandHandler.Handle(new InsertShipCommand(ship), cancellationToken);
        }
    }
}
