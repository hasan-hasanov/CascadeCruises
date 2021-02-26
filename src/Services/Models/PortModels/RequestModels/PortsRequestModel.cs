using MediatR;
using Services.Models.PortModels.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.PortModels.RequestModels
{
    public class PortsRequestModel : IRequest<IEnumerable<PortsResponseModel>> { }
}
