using Adapter.EF.Queries.GetShipById;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.ShipModels.RequestModels;
using Services.Models.ShipModels.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.ShipHandlers
{
    public class GetShipByIdHandler : IRequestHandler<ShipByIdRequestModel, ShipResponseModel>
    {
        private readonly IQueryHandler<GetShipByIdQuery, Ship> _getShipByIdQueryHandler;

        public GetShipByIdHandler(IQueryHandler<GetShipByIdQuery, Ship> getShipByIdQueryHandler)
        {
            _getShipByIdQueryHandler = getShipByIdQueryHandler;
        }

        public async Task<ShipResponseModel> Handle(ShipByIdRequestModel request, CancellationToken cancellationToken)
        {
            Ship ship = await _getShipByIdQueryHandler.HandleAsync(new GetShipByIdQuery(request.Id), cancellationToken);
            return new ShipResponseModel(ship);
        }
    }
}
