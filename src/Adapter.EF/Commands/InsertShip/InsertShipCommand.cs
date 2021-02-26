using Core.Commands;
using Core.Entities;

namespace Adapter.EF.Commands.InsertShip
{
    public class InsertShipCommand : ICommand
    {
        public InsertShipCommand(Ship ship)
        {
            Ship = ship;
        }

        public Ship Ship { get; }
    }
}
