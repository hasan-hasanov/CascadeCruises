using Adapter.EF.Queries.GetCruiseProfits;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.CruiseModels.RequestModels;
using Services.Models.ReportsModel.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.ReportHandlers
{
    public class GetCruisesProfitsHandler : IRequestHandler<CruiseProfitsRequestModel, IEnumerable<CruiseProfitResponseModel>>
    {
        private readonly IQueryHandler<GetCruisesProfitsQuery, IList<CruiseProfit>> _getCruisesProfitsQueryHandler;

        public GetCruisesProfitsHandler(IQueryHandler<GetCruisesProfitsQuery, IList<CruiseProfit>> getCruisesProfitsQueryHandler)
        {
            _getCruisesProfitsQueryHandler = getCruisesProfitsQueryHandler;
        }

        public async Task<IEnumerable<CruiseProfitResponseModel>> Handle(CruiseProfitsRequestModel request, CancellationToken cancellationToken)
        {
            IList<CruiseProfit> cruiseProfits = await _getCruisesProfitsQueryHandler.HandleAsync(new GetCruisesProfitsQuery());
            return cruiseProfits.Select(x => new CruiseProfitResponseModel(x)).ToList();
        }
    }
}
