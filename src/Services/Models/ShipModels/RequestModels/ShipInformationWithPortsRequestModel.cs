using MediatR;
using Services.Models.ReportsModel.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.ShipModels.RequestModels
{
    public class ShipInformationWithPortsRequestModel : IRequest<IEnumerable<ShipInformationWithPortsResponseModel>> { }
}
