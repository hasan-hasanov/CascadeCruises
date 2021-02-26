using Core.Entities;

namespace Services.Models.PortModels.ResponseModels
{
    public class PortsResponseModel
    {
        public PortsResponseModel(Port port)
        {
            Id = port.Id;
            City = port.City;
        }

        public int Id { get; }

        public string City { get; }
    }
}
