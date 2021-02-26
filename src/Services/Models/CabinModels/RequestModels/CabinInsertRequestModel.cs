using Core.Entities;

namespace Services.Models.CabinModels.RequestModels
{
    public class CabinInsertRequestModel
    {
        public int MaxNumberOfPeople { get; }

        public int ClassId { get; }

        public int Number { get; }

        public decimal MaxPrice { get; }

        public Cabin ToCabin()
        {
            return new Cabin()
            {
                MaxNumberOfPeople = MaxNumberOfPeople,
                ClassId = ClassId,
                Number = Number,
                MaxPrice = MaxPrice
            };
        }
    }
}
