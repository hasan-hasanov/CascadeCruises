using Adapter.EF.Queries.GetShipInformation;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.ShipModels.RequestModels;
using Services.Models.ShipModels.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.ShipHandlers
{
    public class GetShipsHandler : IRequestHandler<ShipsRequestModel, IEnumerable<ShipResponseModel>>
    {
        private readonly IQueryHandler<GetShipInformationQuery, IList<Ship>> _getShipInformationQueryHandler;

        public GetShipsHandler(IQueryHandler<GetShipInformationQuery, IList<Ship>> getShipInformationQueryHandler)
        {
            _getShipInformationQueryHandler = getShipInformationQueryHandler;
        }

        public async Task<IEnumerable<ShipResponseModel>> Handle(ShipsRequestModel request, CancellationToken cancellationToken)
        {
            IList<Ship> ships = await _getShipInformationQueryHandler.HandleAsync(new GetShipInformationQuery(), cancellationToken);
            return ships.Select(x => new ShipResponseModel(x)).ToList();
        }
    }
}
