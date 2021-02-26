using Core.Commands;

namespace Adapter.EF.Commands.DeleteCruise
{
    public class DeleteCruiseCommand : ICommand
    {
        public DeleteCruiseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
