using MediatR;

namespace Services.Models.CruiseModels.RequestModels
{
    public class DeleteCruiseRequestModel : IRequest
    {
        public DeleteCruiseRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
