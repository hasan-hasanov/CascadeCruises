using Adapter.EF.Queries.GetProts;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.PortModels.RequestModels;
using Services.Models.PortModels.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.NomenclatureHandlers
{
    public class GetPortsHandler : IRequestHandler<PortsRequestModel, IEnumerable<PortsResponseModel>>
    {
        private readonly IQueryHandler<GetPortsQuery, IList<Port>> _getPortsQueryHandler;

        public GetPortsHandler(IQueryHandler<GetPortsQuery, IList<Port>> getPortsQueryHandler)
        {
            _getPortsQueryHandler = getPortsQueryHandler;
        }

        public async Task<IEnumerable<PortsResponseModel>> Handle(PortsRequestModel request, CancellationToken cancellationToken)
        {
            IList<Port> cabinClasses = await _getPortsQueryHandler.HandleAsync(new GetPortsQuery(), cancellationToken);
            return cabinClasses.Select(c => new PortsResponseModel(c)).ToList();
        }
    }
}
