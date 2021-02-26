using Core.Commands;
using Core.Entities;

namespace Adapter.EF.Commands.UpdateShip
{
    public class UpdateShipCommand : ICommand
    {
        public UpdateShipCommand(Ship ship)
        {
            Ship = ship;
        }

        public Ship Ship { get; }
    }
}
