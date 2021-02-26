using Core.Commands;
using Core.Entities;

namespace Adapter.EF.Commands.UpdatePassenger
{
    public class UpdatePassengerCommand : ICommand
    {
        public UpdatePassengerCommand(Passenger passenger)
        {
            Passenger = passenger;
        }

        public Passenger Passenger { get; }
    }
}
