using MediatR;

namespace Services.Models.PassengerModels.RequestModels
{
    public class DeletePassengerByIdRequestModel : IRequest
    {
        public DeletePassengerByIdRequestModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
