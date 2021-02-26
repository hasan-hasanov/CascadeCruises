using Core.Entities;

namespace Services.Models.CabinModels.RequestModels
{
    public class CabinModifyRequestModel
    {
        public int Id { get; }

        public int MaxNumberOfPeople { get; }

        public int ClassId { get; }

        public int Number { get; }

        public decimal MaxPrice { get; }

        public Cabin ToCabin()
        {
            return new Cabin()
            {
                Id = Id,
                MaxNumberOfPeople = MaxNumberOfPeople,
                ClassId = ClassId,
                Number = Number,
                MaxPrice = MaxPrice
            };
        }
    }
}
