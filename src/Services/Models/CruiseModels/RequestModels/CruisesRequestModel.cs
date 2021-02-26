using MediatR;
using Services.Models.CruiseModels.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.CruiseModels.RequestModels
{
    public class CruisesRequestModel : IRequest<IEnumerable<CruiseResponseModel>> { }
}
