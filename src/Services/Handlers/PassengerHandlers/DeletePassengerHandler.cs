using Adapter.EF.Commands.DeletePassenger;
using Core.Commands;
using MediatR;
using Services.Models.PassengerModels.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.PassengerHandlers
{
    public class DeletePassengerHandler : AsyncRequestHandler<DeletePassengerByIdRequestModel>
    {
        private readonly ICommandHandler<DeletePassengerCommand> _deletePassengerCommandHandler;

        public DeletePassengerHandler(ICommandHandler<DeletePassengerCommand> deletePassengerCommandHandler)
        {
            _deletePassengerCommandHandler = deletePassengerCommandHandler;
        }

        protected override async Task Handle(DeletePassengerByIdRequestModel request, CancellationToken cancellationToken)
        {
            await _deletePassengerCommandHandler.Handle(new DeletePassengerCommand(request.Id), cancellationToken);
        }
    }
}
