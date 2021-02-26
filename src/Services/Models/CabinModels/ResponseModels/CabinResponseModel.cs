using Core.Entities;

namespace Services.Models.CabinModels.ResponseModels
{
    public class CabinResponseModel
    {
        public CabinResponseModel(Cabin cabin)
        {
            Id = cabin.Id;
            MaxNumberOfPeople = cabin.MaxNumberOfPeople;
            ClassId = cabin.ClassId;
            Number = cabin.Number;
            MaxPrice = cabin.MaxPrice;
            CabinClass = new CabinClassResponseModel(cabin.CabinClass);
            CurrentNumberOfPeople = cabin.CurrentNumberOfPeople;
        }

        public int Id { get; }

        public int MaxNumberOfPeople { get; }

        public int CurrentNumberOfPeople { get; }

        public int ClassId { get; }

        public int Number { get; }

        public decimal MaxPrice { get; }

        public CabinClassResponseModel CabinClass { get; }
    }
}
