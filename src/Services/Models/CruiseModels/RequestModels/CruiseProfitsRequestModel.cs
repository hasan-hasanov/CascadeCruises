using MediatR;
using Services.Models.ReportsModel.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.CruiseModels.RequestModels
{
    public class CruiseProfitsRequestModel : IRequest<IEnumerable<CruiseProfitResponseModel>> { }
}
