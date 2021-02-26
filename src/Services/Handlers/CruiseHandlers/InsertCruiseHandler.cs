using Adapter.EF.Commands.InsertCruise;
using Core.Commands;
using Core.Entities;
using Core.Validation;
using MediatR;
using Services.Models.CruiseModels.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.CruiseHandlers
{
    public class InsertCruiseHandler : AsyncRequestHandler<CruiseInsertRequestModel>
    {
        private readonly ICommandHandler<InsertCruiseCommand> _insertCruiseCommandHandler;
        private readonly IValidation<CruiseInsertRequestModel> _cruiseInsertModelValidation;

        public InsertCruiseHandler(
            ICommandHandler<InsertCruiseCommand> insertCruiseCommandHandler,
            IValidation<CruiseInsertRequestModel> cruiseInsertModelValidation)
        {
            _insertCruiseCommandHandler = insertCruiseCommandHandler;
            _cruiseInsertModelValidation = cruiseInsertModelValidation;
        }

        protected override async Task Handle(CruiseInsertRequestModel request, CancellationToken cancellationToken)
        {
            _cruiseInsertModelValidation.Validate(request);

            Cruise cruise = request.ToCruise();
            await _insertCruiseCommandHandler.Handle(new InsertCruiseCommand(cruise), cancellationToken);
        }
    }
}
