using Adapter.EF.Queries.GetShipInformationWithPorts;
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
    public class GetShipInformationWithPortsHandler : IRequestHandler<ShipInformationWithPortsRequestModel, IEnumerable<ShipInformationWithPortsResponseModel>>
    {
        private readonly IQueryHandler<GetShipInformationWithPortsQuery, IList<ShipInformationWithPorts>> _getShipInformationWithPortsQueryHandler;

        public GetShipInformationWithPortsHandler(IQueryHandler<GetShipInformationWithPortsQuery, IList<ShipInformationWithPorts>> getShipInformationWithPortsQueryHandler)
        {
            _getShipInformationWithPortsQueryHandler = getShipInformationWithPortsQueryHandler;
        }

        public async Task<IEnumerable<ShipInformationWithPortsResponseModel>> Handle(ShipInformationWithPortsRequestModel request, CancellationToken cancellationToken)
        {
            IList<ShipInformationWithPorts> shipInformationWithPorts = await _getShipInformationWithPortsQueryHandler.HandleAsync(
                new GetShipInformationWithPortsQuery(),
                cancellationToken);

            return shipInformationWithPorts != null && shipInformationWithPorts.Any() ?
                shipInformationWithPorts.Select(x => new ShipInformationWithPortsResponseModel(x)).ToList() :
                new List<ShipInformationWithPortsResponseModel>();
        }
    }
}
