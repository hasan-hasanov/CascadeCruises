using Adapter.EF.Queries.GetCruiseInformation;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.CruiseModels.RequestModels;
using Services.Models.CruiseModels.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.CruiseHandlers
{
    public class GetCruisesHandler : IRequestHandler<CruisesRequestModel, IEnumerable<CruiseResponseModel>>
    {
        private readonly IQueryHandler<GetCruiseInformationQuery, IList<Cruise>> _getCruiseInformationQueryHandler;

        public GetCruisesHandler(IQueryHandler<GetCruiseInformationQuery, IList<Cruise>> getCruiseInformationQueryHandler)
        {
            _getCruiseInformationQueryHandler = getCruiseInformationQueryHandler;
        }

        public async Task<IEnumerable<CruiseResponseModel>> Handle(CruisesRequestModel request, CancellationToken cancellationToken)
        {
            IEnumerable<Cruise> cruises = await _getCruiseInformationQueryHandler.HandleAsync(new GetCruiseInformationQuery(), cancellationToken);
            return cruises != null && cruises.Any() ? cruises.Select(x => new CruiseResponseModel(x)).ToList() : new List<CruiseResponseModel>();
        }
    }
}
