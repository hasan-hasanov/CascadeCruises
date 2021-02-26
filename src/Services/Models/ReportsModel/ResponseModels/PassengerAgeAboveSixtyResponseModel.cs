using Core.Entities;
using System;

namespace Services.Models.ReportsModel.ResponseModels
{
    public class PassengerAgeAboveSixtyResponseModel
    {
        public PassengerAgeAboveSixtyResponseModel(PassengerAgeAboveSixty passengerAgeAboveSixty)
        {
            Id = passengerAgeAboveSixty.Id;
            Name = passengerAgeAboveSixty.Name;
            Surname = passengerAgeAboveSixty.Surname;
            LastName = passengerAgeAboveSixty.LastName;
            Address = passengerAgeAboveSixty.Address;
            PIN = passengerAgeAboveSixty.PIN;
            DateOfBirth = passengerAgeAboveSixty.DateOfBirth;
        }

        public int Id { get; }

        public string Name { get; }

        public string Surname { get; }

        public string LastName { get; }

        public string Address { get; }

        public string PIN { get; }

        public DateTime DateOfBirth { get; }
    }
}
