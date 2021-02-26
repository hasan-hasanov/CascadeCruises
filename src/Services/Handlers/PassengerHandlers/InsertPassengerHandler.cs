using Adapter.EF.Commands.InsertPassenger;
using Core.Commands;
using Core.Entities;
using Core.Validation;
using MediatR;
using Services.Models.PassengerModels.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.PassengerHandlers
{
    public class InsertPassengerHandler : AsyncRequestHandler<PassengerInsertRequestModel>
    {
        private readonly ICommandHandler<InsertPassengerCommand> _insertPassengerCommandHandler;
        private readonly IValidation<PassengerInsertRequestModel> _passengerInsertModelValidation;

        public InsertPassengerHandler(
            ICommandHandler<InsertPassengerCommand> insertPassengerCommandHandler,
            IValidation<PassengerInsertRequestModel> passengerInsertModelValidation)
        {
            _insertPassengerCommandHandler = insertPassengerCommandHandler;
            _passengerInsertModelValidation = passengerInsertModelValidation;
        }

        protected override async Task Handle(PassengerInsertRequestModel request, CancellationToken cancellationToken)
        {
            _passengerInsertModelValidation.Validate(request);

            Passenger passenger = request.ToPassenger();
            await _insertPassengerCommandHandler.Handle(new InsertPassengerCommand(passenger), cancellationToken);
        }
    }
}
