using Adapter.EF.Commands.DeleteCruise;
using Core.Commands;
using MediatR;
using Services.Models.CruiseModels.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.CruiseHandlers
{
    public class DeleteCruiseHandler : AsyncRequestHandler<DeleteCruiseRequestModel>
    {
        private readonly ICommandHandler<DeleteCruiseCommand> _deleteCruiseCommandHandler;

        public DeleteCruiseHandler(ICommandHandler<DeleteCruiseCommand> deleteCruiseCommandHandler)
        {
            _deleteCruiseCommandHandler = deleteCruiseCommandHandler;
        }

        protected override async Task Handle(DeleteCruiseRequestModel request, CancellationToken cancellationToken)
        {
            await _deleteCruiseCommandHandler.Handle(new DeleteCruiseCommand(request.Id), cancellationToken);
        }
    }
}
