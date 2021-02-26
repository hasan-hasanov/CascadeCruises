using Core.Commands;
using Core.Entities;

namespace Adapter.EF.Commands.InsertPassenger
{
    public class InsertPassengerCommand : ICommand
    {
        public InsertPassengerCommand(Passenger passenger)
        {
            Passenger = passenger;
        }

        public Passenger Passenger { get; }
    }
}
