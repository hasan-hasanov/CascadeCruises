using MediatR;
using Services.Models.ShipModels.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.ShipModels.RequestModels
{
    public class ShipsRequestModel : IRequest<IEnumerable<ShipResponseModel>> { }
}
