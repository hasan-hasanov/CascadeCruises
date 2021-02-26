using Core.Entities;

namespace Services.Models.CabinModels.ResponseModels
{
    public class CabinClassResponseModel
    {
        public CabinClassResponseModel(CabinClass cabinClass)
        {
            Id = cabinClass.Id;
            Class = cabinClass.Class;
        }

        public int Id { get; }

        public string Class { get; }
    }
}
