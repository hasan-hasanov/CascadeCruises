using Adapter.EF.Queries.GetPassengerReservation;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.PassengerModels.RequestModels;
using Services.Models.PassengerModels.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.PassengerHandlers
{
    public class GetPassengerReservationByIdHandler : IRequestHandler<PassengerReservationByIdRequestModel, IEnumerable<PassengerReservationResponseModel>>
    {
        private readonly IQueryHandler<GetPassengerReservationQuery, IList<PassengerReservation>> _getPassengerReservationQueryHandler;

        public GetPassengerReservationByIdHandler(IQueryHandler<GetPassengerReservationQuery, IList<PassengerReservation>> getPassengerReservationQueryHandler)
        {
            _getPassengerReservationQueryHandler = getPassengerReservationQueryHandler;
        }

        public async Task<IEnumerable<PassengerReservationResponseModel>> Handle(PassengerReservationByIdRequestModel request, CancellationToken cancellationToken)
        {
            IList<PassengerReservation> passengerReservations = await _getPassengerReservationQueryHandler.HandleAsync(
                new GetPassengerReservationQuery(request.Id),
                cancellationToken);

            return passengerReservations.Select(x => new PassengerReservationResponseModel(x)).ToList();
        }
    }
}
