using Adapter.EF.Commands.UpdateCruise;
using Core.Commands;
using Core.Entities;
using Core.Validation;
using MediatR;
using Services.Models.CruiseModels.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.CruiseHandlers
{
    public class UpdateCruiseHandler : AsyncRequestHandler<CruiseModfiyRequestModel>
    {
        private readonly ICommandHandler<UpdateCruiseCommand> _updateCruiseCommandHandler;
        private readonly IValidation<CruiseModfiyRequestModel> _cruiseModifyModelValidation;

        public UpdateCruiseHandler(
            ICommandHandler<UpdateCruiseCommand> updateCruiseCommandHandler,
            IValidation<CruiseModfiyRequestModel> cruiseModifyModelValidation)
        {
            _updateCruiseCommandHandler = updateCruiseCommandHandler;
            _cruiseModifyModelValidation = cruiseModifyModelValidation;
        }

        protected override async Task Handle(CruiseModfiyRequestModel request, CancellationToken cancellationToken)
        {
            _cruiseModifyModelValidation.Validate(request);

            Cruise cruise = request.ToCruise();
            await _updateCruiseCommandHandler.Handle(new UpdateCruiseCommand(cruise), cancellationToken);
        }
    }
}
