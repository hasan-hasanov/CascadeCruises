using MediatR;
using Services.Models.ShipModels.ResponseModels;

namespace Services.Models.ShipModels.RequestModels
{
    public class ShipByIdRequestModel : IRequest<ShipResponseModel>
    {
        public ShipByIdRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
