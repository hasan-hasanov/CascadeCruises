using MediatR;
using Services.Models.PassengerModels.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.PassengerModels.RequestModels
{
    public class PassengerReservationByIdRequestModel : IRequest<IEnumerable<PassengerReservationResponseModel>>
    {
        public PassengerReservationByIdRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
