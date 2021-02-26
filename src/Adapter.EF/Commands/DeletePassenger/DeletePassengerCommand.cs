using Core.Commands;

namespace Adapter.EF.Commands.DeletePassenger
{
    public class DeletePassengerCommand : ICommand
    {
        public DeletePassengerCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
