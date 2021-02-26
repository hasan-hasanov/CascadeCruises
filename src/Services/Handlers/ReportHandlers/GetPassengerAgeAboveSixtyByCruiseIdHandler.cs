using Adapter.EF.Queries.GetPassengerAgeAboveSixty;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.ReportsModel.RequestModels;
using Services.Models.ReportsModel.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.ReportHandlers
{
    public class GetPassengerAgeAboveSixtyByCruiseIdHandler : IRequestHandler<PassengerAgeAboveSixtyByCruiseIdRequestModel, IEnumerable<PassengerAgeAboveSixtyResponseModel>>
    {
        private readonly IQueryHandler<GetPassengersAgeAboveSixtyQuery, IList<PassengerAgeAboveSixty>> _getPassengerAgeAboveSixtyQueryHandler;

        public GetPassengerAgeAboveSixtyByCruiseIdHandler(IQueryHandler<GetPassengersAgeAboveSixtyQuery, IList<PassengerAgeAboveSixty>> getPassengerAgeAboveSixtyQueryHandler)
        {
            _getPassengerAgeAboveSixtyQueryHandler = getPassengerAgeAboveSixtyQueryHandler;
        }

        public async Task<IEnumerable<PassengerAgeAboveSixtyResponseModel>> Handle(PassengerAgeAboveSixtyByCruiseIdRequestModel request, CancellationToken cancellationToken)
        {
            IList<PassengerAgeAboveSixty> passengerAgeAboveSixties = await _getPassengerAgeAboveSixtyQueryHandler.HandleAsync(
                new GetPassengersAgeAboveSixtyQuery(request.Id),
                cancellationToken);

            return passengerAgeAboveSixties != null && passengerAgeAboveSixties.Any() ?
                passengerAgeAboveSixties.Select(x => new PassengerAgeAboveSixtyResponseModel(x)).ToList() :
                new List<PassengerAgeAboveSixtyResponseModel>();
        }
    }
}
