using Adapter.EF.Queries.GetShipByMaxRoomsCount;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.ReportsModel.ResponseModels;
using Services.Models.ShipModels.RequestModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.ReportHandlers
{
    public class GetShipByMaxRoomsCountHandler : IRequestHandler<ShipByMaxRoomsCountRequestModel, IEnumerable<ShipByMaxRoomsCountResponseModel>>
    {
        private readonly IQueryHandler<GetShipByMaxRoomsCountQuery, IList<ShipByMaxRoomsCount>> _getShipByMaxRoomsCountQueryHandler;

        public GetShipByMaxRoomsCountHandler(IQueryHandler<GetShipByMaxRoomsCountQuery, IList<ShipByMaxRoomsCount>> getShipByMaxRoomsCountQueryHandler)
        {
            _getShipByMaxRoomsCountQueryHandler = getShipByMaxRoomsCountQueryHandler;
        }

        public async Task<IEnumerable<ShipByMaxRoomsCountResponseModel>> Handle(ShipByMaxRoomsCountRequestModel request, CancellationToken cancellationToken)
        {
            IList<ShipByMaxRoomsCount> shipsByMaxRoomsCount = await _getShipByMaxRoomsCountQueryHandler.HandleAsync(new GetShipByMaxRoomsCountQuery(), cancellationToken);
            return shipsByMaxRoomsCount != null && shipsByMaxRoomsCount.Any() ?
                shipsByMaxRoomsCount.Select(x => new ShipByMaxRoomsCountResponseModel(x)).ToList() :
                new List<ShipByMaxRoomsCountResponseModel>();
        }
    }
}
