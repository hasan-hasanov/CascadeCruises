using Core.Entities;
using MediatR;
using System;

namespace Services.Models.PassengerModels.RequestModels
{
    public class PassengerInsertRequestModel : IRequest
    {
        public string Name { get; }

        public string Surname { get; }

        public string LastName { get; }

        public string Address { get; }

        public string PIN { get; }

        public DateTime DateOfBirth { get; }

        public Passenger ToPassenger()
        {
            return new Passenger()
            {
                Name = Name,
                Surname = Surname,
                LastName = LastName,
                Address = Address,
                PIN = PIN,
                DateOfBirth = DateOfBirth
            };
        }
    }
}
