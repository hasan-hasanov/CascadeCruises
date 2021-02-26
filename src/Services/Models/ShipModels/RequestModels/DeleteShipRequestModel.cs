using MediatR;

namespace Services.Models.ShipModels.RequestModels
{
    public class DeleteShipRequestModel : IRequest
    {
        public DeleteShipRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
