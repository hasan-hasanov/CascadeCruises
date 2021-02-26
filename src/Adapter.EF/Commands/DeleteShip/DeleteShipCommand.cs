using Core.Commands;

namespace Adapter.EF.Commands.DeleteShip
{
    public class DeleteShipCommand : ICommand
    {
        public DeleteShipCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
