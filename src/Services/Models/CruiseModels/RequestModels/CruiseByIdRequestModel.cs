using MediatR;
using Services.Models.CruiseModels.ResponseModels;

namespace Services.Models.CruiseModels.RequestModels
{
    public class CruiseByIdRequestModel : IRequest<CruiseResponseModel>
    {
        public CruiseByIdRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
