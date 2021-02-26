using MediatR;
using Services.Models.CabinModels.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.CabinModels.RequestModels
{
    public class CabinClassesRequestModel : IRequest<IEnumerable<CabinClassResponseModel>> { }
}
