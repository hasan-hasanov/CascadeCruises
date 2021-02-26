using MediatR;
using Services.Models.ReportsModel.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.ReportsModel.RequestModels
{
    public class PassengerAgeAboveSixtyByCruiseIdRequestModel : IRequest<IEnumerable<PassengerAgeAboveSixtyResponseModel>>
    {
        public PassengerAgeAboveSixtyByCruiseIdRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
