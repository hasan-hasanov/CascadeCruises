using Core.Entities;
using MediatR;
using System;

namespace Services.Models.PassengerModels.ResponseModels
{
    public class PassengerResponseModel : IRequest
    {
        public PassengerResponseModel() { }

        public PassengerResponseModel(Passenger passenger)
        {
            Id = passenger.Id;
            PIN = passenger.PIN;
            Name = passenger.Name;
            LastName = passenger.LastName;
            Address = passenger.Address;
        }

        public int Id { get; }

        public string PIN { get; }

        public string Name { get; }

        public string Surname { get; }

        public string LastName { get; }

        public string Address { get; }

        public DateTime DateOfBirth { get; }

        public Passenger ToPassenger()
        {
            return new Passenger()
            {
                Id = Id,
                Address = Address,
                DateOfBirth = DateOfBirth,
                LastName = LastName,
                Name = Name,
                PIN = PIN,
                Surname = Surname
            };
        }
    }
}
