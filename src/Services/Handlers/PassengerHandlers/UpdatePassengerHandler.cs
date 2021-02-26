using Adapter.EF.Commands.UpdatePassenger;
using Core.Commands;
using Core.Entities;
using MediatR;
using Services.Models.PassengerModels.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.PassengerHandlers
{
    public class UpdatePassengerHandler : AsyncRequestHandler<PassengerResponseModel>
    {
        private readonly ICommandHandler<UpdatePassengerCommand> _updatePassengerCommandHandler;

        public UpdatePassengerHandler(ICommandHandler<UpdatePassengerCommand> updatePassengerCommandHandler)
        {
            _updatePassengerCommandHandler = updatePassengerCommandHandler;
        }

        protected override async Task Handle(PassengerResponseModel request, CancellationToken cancellationToken)
        {
            Passenger passenger = request.ToPassenger();
            await _updatePassengerCommandHandler.Handle(new UpdatePassengerCommand(passenger), cancellationToken);
        }
    }
}
